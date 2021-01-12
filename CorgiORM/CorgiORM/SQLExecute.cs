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
        List<T> execute<T>(ISelectQueryBuilder Query);
        Object executeGetFirst(ISelectQueryBuilder Query);
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

        protected virtual int applyRowChange(DataRow row)
        {
            return 0;
        }

        protected void connectAndLoadData()
        {
            try
            {
            this.dataAdapter = new SqlDataAdapter(queryString,this.connectionString);
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
            this.queryString = $"select * from {tableName}";
            try
            {
            //connect to db
            connectAndLoadData();
            //build row to change in table
            var row = getDataFromObject(Object);
            //apply row to table with child define method
            int indexEffected = applyRowChange(row);

            //update to db
            int res = this.dataAdapter.Update(dataSet.Tables[tableName]);
            connectAndLoadData();

            Debug.WriteLine($"CorgiORM: {res} row(s) effected!!! Primary value: {dataSet.Tables[tableName].Rows[indexEffected][0]}");
            }
            catch (Exception)
            {
                Debug.WriteLine("CorgiORM: Connection Error...");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Query"></param>
        /// <returns></returns>
        public virtual List<T> execute<T>(ISelectQueryBuilder Query)
        {
            try
            {
                this.queryString = Query.getQueryString();
                connectAndLoadData();

                //mapping dataset => list... and return list
                List<T> res = new List<T>();


                return res;
            }
            catch (Exception)
            {
                return null;

                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public virtual Object executeGetFirst(ISelectQueryBuilder Query)
        {
            this.queryString = Query.getQueryString();
            try
            {
                connectAndLoadData();

                //mapping dataset.table.row[0] => object... and return it

                Object res = new Object();


                return res;
            }
            catch (Exception)
            {
                return null;

                throw;
            }
        }
    }

    public class SqlAdd : SQLExecute
    {
        public SqlAdd(string connectionString) : base(connectionString)
        {

        }

        protected override int applyRowChange(DataRow row)
        {
            try
            {
                //add row to table in database
                dataSet.Tables[tableName].Rows.Add(row);

                return dataSet.Tables[tableName].Rows.Count-1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //public override void execute(string tableName)
        //{
        //    return;
        //}

        //public override void executeGetFirst(string tableName)
        //{
        //    return;
        //}
    }

    public class SqlUpdate : SQLExecute
    {
        public SqlUpdate(string connectionString) : base(connectionString)
        {

        }

        protected override int applyRowChange(DataRow row)
        {
            try
            {
                //find row in table
                int index = -1, pos = 0;
                foreach (DataRow x in dataSet.Tables[tableName].Rows)
                {
                    if (x[0].Equals(row[0]))
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

                return index;
            }
            catch (Exception)
            {
                return -1;
            }
        }

    }

    public class SqlRemove : SQLExecute
    {
        public SqlRemove(string connectionString) : base(connectionString)
        {

        }

        protected override int applyRowChange(DataRow row)
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

                return index;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }

    public class SqlGet: SQLExecute
    {
       
        public SqlGet(string connectionString) : base(connectionString)
        {

        }

        protected override int applyRowChange(DataRow row)
        {
            return 1;
        }

        public override void executeNonQuery<T>(string tableName, T Object)
        {
            return;
        }

    }

}
