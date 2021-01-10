using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class ORM <T> where T: new()
    {
        private string table;

        private ConfigDB ConfigDB;

        private ParserDB ParserDB;

        private Dictionary<string, string> attributesList = new Dictionary<string, string>();

        private List<string> primaryKeyList = new List<string>();

        private List<string> autoIncrementList = new List<string>();

        public ORM(ConfigDB configDB,ParserDB parserDB)
        {
            Type type = typeof(T);

            this.table = type.GetCustomAttribute<TableName>().table;
            this.ConfigDB = configDB;
            this.ParserDB = parserDB;

            PropertyInfo[] attributes = type.GetProperties();
            foreach(PropertyInfo attribute in attributes)
            {
                if (attribute.GetCustomAttribute<Column>() != null)
                {
                    attributesList.Add(attribute.Name, attribute.GetCustomAttribute<Column>().column);
                    if (attribute.GetCustomAttribute<Column>().primaryKey)
                    {
                        primaryKeyList.Add(attribute.Name);
                    }

                    if (attribute.GetCustomAttribute<Column>().autoIncrement)
                    {
                        autoIncrementList.Add(attribute.Name);
                    }
                }
            }
        }
        public InsertQuery Insert(T data)
        {
            Dictionary<string, Object> insertValues = new Dictionary<string, Object>();
            foreach (string attribute in attributesList.Keys)
            {
                Object value = GetValueMappingColumn(data, attribute);
                if (!(autoIncrementList.Contains(attribute)) && !(value is ICollection) && !(data is ICollection))
                {
                    insertValues.Add(attribute, value);
                }
            }
            return new InsertQuery(table, ConfigDB, ParserDB, attributesList, insertValues);
        }

        Object GetValueMappingColumn(Object obj,string attribute)
        {
            return obj.GetType().GetProperty(attribute).GetValue(obj, null);
        }

        public SelectQuery<T> Select()
        {
            return new SelectQuery<T>(table, ConfigDB, ParserDB, attributesList);
        }

        public DeleteQuery Delete(T obj)
        {
            AndCondition conditionDelete = new AndCondition();
            foreach (string attribute in attributesList.Keys)
            {
                Object value = GetValueMappingColumn(obj, attribute);
                if (!(value is ICollection) && !(obj is ICollection))
                {
                    conditionDelete.Add(Condition.Equal(attribute, value));
                }
            }
            return new DeleteQuery(table, ConfigDB, ParserDB, attributesList, conditionDelete);
        }

        public DeleteQuery Delete()
        {
            return new DeleteQuery(table, ConfigDB, ParserDB, attributesList);
        }

        public DeleteQuery Delete(Condition conditionDelete)
        {
            return new DeleteQuery(table, ConfigDB, ParserDB, attributesList, conditionDelete);
        }
        public UpdateQuery Update(T data)
        {
            Dictionary<string, Object> updateValues = new Dictionary<string, object>();
            foreach (string attribute in attributesList.Keys)
            {
                if (!(primaryKeyList.Contains(attribute)))
                {
                    updateValues.Add(attribute, GetValueMappingColumn(data, attribute));
                }
            }

            AndCondition conditionUpdate = new AndCondition();
            foreach (string key in primaryKeyList)
            {
                conditionUpdate.Add(Condition.Equal(key, GetValueMappingColumn(data, key)));
            }
            return new UpdateQuery(table, ConfigDB, ParserDB, attributesList, updateValues, conditionUpdate);
        }
        public UpdateQuery Update()
        {
            return new UpdateQuery(table, ConfigDB, ParserDB, attributesList);
        }
    }
}
