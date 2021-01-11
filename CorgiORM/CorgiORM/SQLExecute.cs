using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    public interface IExecute
    {
        void execute<T>(string tableName, T Object);
    }

    public class SQLExecute : IExecute
    {
        protected string connectionString;
        protected string tableName;
        protected string queryString;

        public SQLExecute(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected virtual string buildQuery<T>(string tableName, T Object)
        {
            return null;
        }

        public void execute<T>(string tableName, T Object)
        {
            this.queryString = buildQuery<T>(tableName, Object);
            Console.WriteLine($"{connectionString} -- {queryString} -- {tableName}");
        }
    }

    public class SqlAdd : SQLExecute
    {
        public SqlAdd(string connectionString) : base(connectionString)
        {

        }

        protected override string buildQuery<T>(string tableName, T Object)
        {
            return "Add";
        }
    }

    public class SqlUpdate : SQLExecute
    {
        public SqlUpdate(string connectionString) : base(connectionString)
        {

        }

        protected override string buildQuery<T>(string tableName, T Object)
        {
            return "SqlUpdate";
        }
    }

    public class SqlRemove : SQLExecute
    {
        public SqlRemove(string connectionString) : base(connectionString)
        {

        }

        protected override string buildQuery<T>(string tableName, T Object)
        {
            return "SqlRemove";
        }
    }

    public class SqlGetAll: SQLExecute
    {
        public SqlGetAll(string connectionString) : base(connectionString)
        {

        }

        protected override string buildQuery<T>(string tableName, T Object)
        {
            return "SqlGetAll";
        }
    }

    public class SqlGet: SQLExecute
    {
        public SqlGet(string connectionString) : base(connectionString)
        {

        }

        protected override string buildQuery<T>(string tableName, T Object)
        {
            return "SqlGet";
        }
    }

}
