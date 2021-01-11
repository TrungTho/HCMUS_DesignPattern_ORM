using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace CorgiORM
{
    class Program
    {
        public class CorgiORM
        {
            private string connectionString;

            public string ConnectionString { get => connectionString; set => connectionString = value; }

            public IExecute CorgiAdd;
            public IExecute CorgiUpdate;

            public CorgiORM(string connectionString)
            {
                this.connectionString = connectionString;
                getExecuteType();
            }

            private void getExecuteType()
            {
                this.CorgiAdd = new SqlAdd(this.connectionString);
                this.CorgiUpdate = new SqlUpdate(this.connectionString);
            }
        }

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
                Console.WriteLine($"{queryString} -- {tableName}");
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

        static void Main(string[] args)
        {
            CorgiORM corgiORM = new CorgiORM("dbconnectionstring");
            corgiORM.CorgiAdd.execute("user", 1);
            corgiORM.CorgiUpdate.execute("customer", 2);
            Console.ReadKey();
        }
    }
}