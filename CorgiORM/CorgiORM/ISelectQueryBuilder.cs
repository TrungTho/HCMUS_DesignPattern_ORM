using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    public interface ISelectQueryBuilder
    {
        string getQueryString();
        ISelectQueryBuilder Where(string fieldName, Object value);
        ISelectQueryBuilder GroupBy(string fieldName);
    }

    public class SQLSelectBuilder: ISelectQueryBuilder
    {
        private string whereCondition;
        private string groupByCondition;
        private string havingCondition;
        private string orderByCondition;
        private string tableName;

        public SQLSelectBuilder(string table)
        {
            this.tableName = table;
        }
        public string getGroupByStr()
        {
            return groupByCondition.Substring(0, groupByCondition.Length-1) + ")";
        }
        public string getQueryString()
        {
            return $"select * from {tableName} {whereCondition} {getGroupByStr()} {havingCondition} {orderByCondition}";
        }

        public string getValue(Object obj)
        {
            if (obj.GetType() == typeof(string))
                return "\"" + obj.ToString() + "\"";
            else if (obj.GetType() == typeof(DateTime))
            {
                return "\"" + ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
            }
            return obj.ToString();
        }

        public ISelectQueryBuilder GroupBy(string fieldName)
        {
            if (this.groupByCondition == null)
            {
                this.groupByCondition = "GROUP BY(" + fieldName;
            }
            else
            {
                this.groupByCondition += "," + fieldName;
            }
            return this;
        }

        public ISelectQueryBuilder Where(string fieldName, Object value)
        {
            if(this.whereCondition == null)
            {
                this.whereCondition = "WHERE " + fieldName + "=" + getValue(value);
            }
            else
            {
                this.whereCondition += "AND " + fieldName + "=" + getValue(value);
            }
            return this;
        }
    }


}
