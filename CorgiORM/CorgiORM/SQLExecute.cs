using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace CorgiORM
{
    public interface IExecute
    {
        void executeNonQuery<T>(string tableName, T Object);
        void execute<T>(string tableName, T Object);
        void executeGetFirst<T>(string tableName, T Object);
    }

    public class SQLExecute : IExecute
    {
        protected string connectionString;
        protected string queryString;
        protected string tableName;
        protected SqlDataAdapter dataAdapter;
        protected SqlCommandBuilder commandBuilder;
        protected DataSet dataSet;
        
        public SQLExecute(string connectionString)
        {
            this.connectionString = connectionString;

        }

        protected virtual bool buildRow<T>(T Object)
        {
            return true;
        }

        protected void connect()
        {
            try
            {
            this.dataAdapter = new SqlDataAdapter($"select * from {tableName}",this.connectionString);
            this.commandBuilder = new SqlCommandBuilder(this.dataAdapter);

            this.dataSet = new DataSet();
            dataAdapter.Fill(dataSet, tableName);
            }
            catch (Exception)
            {
                Debug.WriteLine("CorgiORM: Connection Error...");
            }
        }

        /// <summary>
        /// For insert/update/delete query
        /// </summary>
        /// <typeparam name="T"> class variable</typeparam>
        /// <param name="tableName"> table name that apply query</param>
        /// <param name="Object"> object that need to insert/delete/update to database</param>
        public virtual void executeNonQuery<T>(string tableName, T Object)
        {
            this.tableName = tableName;
            try
            {
            //connect to db
            connect();
            //build row to change in table
            buildRow<T>(Object);

            int res = this.dataAdapter.Update(dataSet.Tables[tableName]);

            Debug.WriteLine($"CorgiORM: {res} row(s) effected!!!");
            }
            catch (Exception)
            {
                Debug.WriteLine("CorgiORM: Connection Error...");
            }
        }

        public virtual void execute<T>(string tableName, T Object)
        {
            this.tableName = tableName;

            Console.WriteLine($"{connectionString} \n {queryString} \n {tableName}");
        }

        public virtual void executeGetFirst<T>(string tableName, T Object)
        {
            this.tableName = tableName;

            Console.WriteLine($"{connectionString} \n {queryString} \n {tableName}");
        }

        protected DataRow getDataFromObject<T>(T Object)
        {
            try
            {
                var row = dataSet.Tables[tableName].NewRow();
                int pos = 0;

                //extract values from object to row one by one
                foreach (PropertyInfo attri in Object.GetType().GetProperties())
                {
                    var value = attri.GetValue(Object, null);
                    row[pos] = value;
                    pos++;
                }

                return row;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }

    public class SqlAdd : SQLExecute
    {
        public SqlAdd(string connectionString) : base(connectionString)
        {

        }

        protected override bool buildRow<T>(T Object)
        {
            try
            {
                //add row to table in database
                dataSet.Tables[tableName].Rows.Add(getDataFromObject(Object));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class SqlUpdate : SQLExecute
    {
        public SqlUpdate(string connectionString) : base(connectionString)
        {

        }

        protected override bool buildRow<T>(T Object)
        {
            return true;
        }
    }

    public class SqlRemove : SQLExecute
    {
        public SqlRemove(string connectionString) : base(connectionString)
        {

        }

        protected override bool buildRow<T>(T Object)
        {
            return true;
        }
    }

    public class SqlGetAll: SQLExecute
    {
        public SqlGetAll(string connectionString) : base(connectionString)
        {

        }

        protected override bool buildRow<T>(T Object)
        {
            return true;
        }
    }

    public class SqlGet: SQLExecute
    {
        public SqlGet(string connectionString) : base(connectionString)
        {

        }

        protected override bool buildRow<T>(T Object)
        {
            return true;
        }
    }

}
