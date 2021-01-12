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
    }

    public class SQLSelectBuilder: ISelectQueryBuilder
    {
        private string whereCondition;
        private string groupByCondition;
        private string havingCondition;
        private string orderByCondition;
        private string tableName;

        public string getQueryString()
        {
            return $"select * from {tableName} {whereCondition} {groupByCondition} {havingCondition} {orderByCondition}";
        }
    }
}
