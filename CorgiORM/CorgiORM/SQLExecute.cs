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

        protected virtual bool applyRowChange(DataRow row)
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

        protected bool compareRow(DataRow row1, DataRow row2, int size)
        {
            for (int i = 0; i < size; i++)
                if (row1[i].Equals(row2[i]) == false)
                    return false;

            return true;
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
            var row = getDataFromObject(Object);
            //apply row to table with child define method
            applyRowChange(row);

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
    }

    public class SqlAdd : SQLExecute
    {
        public SqlAdd(string connectionString) : base(connectionString)
        {

        }

        protected override bool applyRowChange(DataRow row)
        {
            try
            {
                //add row to table in database
                dataSet.Tables[tableName].Rows.Add(row);

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

        protected override bool applyRowChange(DataRow row)
        {
            try
            {
                //find row in table
                int index = -1, pos = 0;
                foreach (DataRow x in dataSet.Tables[tableName].Rows)
                {
                    if (compareRow(x, row, dataSet.Tables[tableName].Columns.Count))
                        index = pos;
                    pos++;
                }

                if (index!=-1)
                {
                    dataSet.Tables[tableName].Rows[index].BeginEdit();
                    for (var i=0;i<dataSet.Tables[tableName].Columns.Count;i++)
                    {
                        dataSet.Tables[tableName].Rows[index][i] = row[i];
                    }

                    dataSet.Tables[tableName].Rows[index].EndEdit();
                    

                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class SqlRemove : SQLExecute
    {
        public SqlRemove(string connectionString) : base(connectionString)
        {

        }

        protected override bool applyRowChange(DataRow row)
        {
            try
            {
                //find row in table
                int index = -1, pos = 0;
                foreach (DataRow x in dataSet.Tables[tableName].Rows)
                {
                    if (compareRow(x,row,dataSet.Tables[tableName].Columns.Count))
                        index = pos;
                    pos++;
                }

                //Console.WriteLine(index);

                if (index != -1)
                {
                    dataSet.Tables[tableName].Rows[index].Delete();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class SqlGetAll: SQLExecute
    {
        public SqlGetAll(string connectionString) : base(connectionString)
        {

        }

        protected override bool applyRowChange(DataRow row)
        {
            return true;
        }
    }

    public class SqlGet: SQLExecute
    {
        public SqlGet(string connectionString) : base(connectionString)
        {

        }

        protected override bool applyRowChange(DataRow row)
        {
            return true;
        }
    }

}
