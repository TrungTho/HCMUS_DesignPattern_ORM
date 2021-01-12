using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    public enum DatabaseType
    {
       SQL,
       NoSQL
    }

    public class CorgiORM
    {
        private static CorgiORM _db;
        public static CorgiORM DB {
            get
            {
                if (_db == null)
                    _db = new CorgiORM(connectionString);
                return _db;
            }
            set => _db = value;
        }

        private static string connectionString;
        private DatabaseType DBType;

        protected string ConnectionString { get => connectionString; set => connectionString = value; }

        public IExecute CorgiAdd;
        public IExecute CorgiUpdate;
        public IExecute CorgiRemove;
        public IExecute CorgiGet;

        private CorgiORM(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void Config(string connectionString, DatabaseType DBType)
        {
            this.ConnectionString = connectionString;
            this.DBType = DBType;
            getExecuteType(DBType);
        }

        private void getExecuteType(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.SQL:
                    this.CorgiAdd = new SqlAdd(this.ConnectionString);
                    this.CorgiUpdate = new SqlUpdate(this.ConnectionString);
                    this.CorgiRemove = new SqlRemove(this.ConnectionString);
                    this.CorgiGet = new SqlGet(this.ConnectionString);

                    break;
                case DatabaseType.NoSQL:
                    break;
                default:
                    break;
            }
        }
    }
}
