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
        private Dictionary<string, string> attributesList = new Dictionary<string, string>();

        private List<string> primaryKeyList = new List<string>();

        private List<string> autoIncrementList = new List<string>();

        private string table;

        private ConfigDB ConfigDB;

        private ParserDB ParserDB;

        public ORM(ConfigDB configDB,ParserDB parserDB)
        {
            Type type = typeof(T);
            this.ConfigDB = configDB;
            this.table = type.GetCustomAttribute<TableName>().tableName;
            this.ParserDB = parserDB;
            PropertyInfo[] attributes = type.GetProperties();
            
            foreach(PropertyInfo attribute in attributes)
            {
                //Console.WriteLine(attribute.GetCustomAttribute<Column>().columnName);
                // Console.WriteLine(attribute.Name);
                if (attribute.GetCustomAttribute<Column>() == null)
                {
                    continue;
                }

                attributesList.Add(attribute.Name, attribute.GetCustomAttribute<Column>().columnName);
                if (attribute.GetCustomAttribute<Column>().isKey)
                {
                    primaryKeyList.Add(attribute.Name);
                }

                if(attribute.GetCustomAttribute<Column>().autoincrement)
                {
                    autoIncrementList.Add(attribute.Name);
                }
            }
        }

        Object GetValueWithPropName(Object obj,string propName)
        {
            return obj.GetType().GetProperty(propName).GetValue(obj, null);
        }

        public SelectQuery<T> Select()
        {
            return new SelectQuery<T>(table, ConfigDB, ParserDB, attributesList);
        }

        public InsertQuery Insert(T obj)
        {
            Dictionary<string, Object> valueMap = new Dictionary<string, Object>();
            //Iterate through attributes of class
            foreach (string attr in attributesList.Keys)
            {
                Object value = GetValueWithPropName(obj, attr);
                //Check if attribute is a list or dictionary
                if (!(value is ICollection) && !(obj is ICollection))
                {
                    if (autoIncrementList.Contains(attr))
                    {
                        continue;
                    }
                    valueMap.Add(attr, value);
                }
            }
          
            return new InsertQuery(table, ConfigDB, ParserDB, attributesList, valueMap);
        }

        public DeleteQuery Delete(T obj)
        {
            AndCondition condition = new AndCondition();
            foreach (string attr in attributesList.Keys)
            {
                Object value = GetValueWithPropName(obj, attr);
                //Check if attribute is a list or dictionary
                if (!(value is ICollection) && !(obj is ICollection))
                {
                    condition.Add(Condition.Equal(attr, value));
                }
            }
            return new DeleteQuery(table, ConfigDB, ParserDB, attributesList, condition);
        }

        public DeleteQuery Delete()
        {
            return new DeleteQuery(table, ConfigDB, ParserDB, attributesList);
        }

        public DeleteQuery Delete(Condition condition)
        {
            return new DeleteQuery(table, ConfigDB, ParserDB, attributesList, condition);
        }

    }
}
