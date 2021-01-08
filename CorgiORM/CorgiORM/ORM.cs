using System;
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
                Console.WriteLine(attribute.GetCustomAttribute<Column>().columnName);
                 Console.WriteLine(attribute.Name);
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


    }
}
