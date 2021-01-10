using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class ParserMySQL : ParserDB
    {
        public override string ParseDeleteQuery(string table, string conditionDelete)
        {
            if(conditionDelete!="")
            {
                string query = "DELETE FROM " + table + " WHERE " + conditionDelete;
                return query;
            }
            else
            {
                string query = "DELETE FROM " + table;
                return query;
            }
        }

        public override string ParseInsertQuery(string table, Dictionary<string, string> values)
        {
            string query = "INSERT INTO " + table + "(";
            foreach (string key in values.Keys.ToArray())
            {
                query += key + ",";
            }
            query = query.Remove(query.Length - 1, 1) + ")";
            query += " VALUES (";
            foreach (string value in values.Values.ToArray())
            {
                query += value + ",";
            }
            query = query.Remove(query.Length - 1, 1) + ")";
            return query;
        }

        public override string ParseSelectQuery(string table, string projections, string where, string groupBy = "", string having = "", string orderBy = "")
        {
            string query = "SELECT " + projections + " FROM " + table;
            if (where.Length != 0)
            {
                query += " WHERE " + where;
            }
            if (groupBy.Length != 0)
            {
                query += " GROUP BY " + groupBy;
                if (having.Length != 0)
                {
                    query += " HAVING " + having;
                }
            }
            if (orderBy.Length != 0)
            {
                query += " ORDER BY " + orderBy;
            }
            //Console.WriteLine(query);
            return query;
        }

        public override string ParseUpdateQuery(string table, Dictionary<string, string> newValues, string condition)
        {
            string query = "UPDATE " + table + " SET ";
            foreach (string key in newValues.Keys.ToArray())
            {
                query += key + "=" + newValues[key] + ",";
            }
            query = query.Remove(query.Length - 1, 1) + " WHERE " + condition;
            //Console.WriteLine(query);
            return query;
        }

        public override string ParseValue(object obj, Type type)
        {
            if (type == typeof(string))
                return "\"" + obj.ToString() + "\"";
            else if (type == typeof(DateTime))
            {
                return "\"" + ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
            }
            return obj.ToString();
        }
    }
}
