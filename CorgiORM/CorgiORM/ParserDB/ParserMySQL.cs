using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class ParserMySQL : ParserDB
    {
        public override string ParseDataToTableValue(object obj, Type dataType)
        {
            if (dataType == typeof(string))
            {
                return "\"" + obj.ToString() + "\"";
            }
            else if (dataType == typeof(DateTime))
            {
                return "\"" + ((DateTime)obj).ToString("yyyy-MM-dd") + "\"";
            }
            return obj.ToString();
        }
        public override string ParseDataToInsertQuery(string table, Dictionary<string, string> dataInsert)
        {
            string insertQuery = "INSERT INTO " + table + "(";
            foreach (string key in dataInsert.Keys.ToArray())
            {
                insertQuery += key + ",";
            }
            //get attribute insert
            insertQuery = insertQuery.Remove(insertQuery.Length - 1, 1) + ")";
            insertQuery += " VALUES (";

            //get value insert
            foreach (string value in dataInsert.Values.ToArray())
            {
                insertQuery += value + ",";
            }
            insertQuery = insertQuery.Remove(insertQuery.Length - 1, 1) + ")";

            return insertQuery;
        }
        public override string ParseDataToDeleteQuery(string table, string condition)
        {
            string deleteQuery = "DELETE FROM " + table;
            if (condition != "")
            {
                deleteQuery += " WHERE " + condition;
            }
            return deleteQuery;
        }

        public override string ParseDataToSelectQuery(string table, string columnsReturn, string condition, string groupBy = "", string having = "", string orderBy = "")
        {
            string selectQuery = "SELECT " + columnsReturn + " FROM " + table;

            if (condition.Length != 0)
            {
                selectQuery += " WHERE " + condition;
            }

            if (groupBy.Length != 0)
            {
                selectQuery += " GROUP BY " + groupBy;
                if (having.Length != 0)
                {
                    selectQuery += " HAVING " + having;
                }
            }

            if (orderBy.Length != 0)
            {
                selectQuery += " ORDER BY " + orderBy;
            }
            return selectQuery;
        }

        public override string ParseDataToUpdateQuery(string table, Dictionary<string, string> newValues, string condition)
        {
            string updateQuery = "UPDATE " + table + " SET ";
            foreach (string key in newValues.Keys.ToArray())
            {
                updateQuery += key + "=" + newValues[key] + ",";
            }
            updateQuery = updateQuery.Remove(updateQuery.Length - 1, 1);

            if(condition!="")
            {
                updateQuery+= " WHERE " + condition;
            }
          
            return updateQuery;
        }

    }
}
