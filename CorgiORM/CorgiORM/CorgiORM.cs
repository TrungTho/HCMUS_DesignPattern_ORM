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
        private static CorgiORM _instance;
        public static CorgiORM Instance {
            get
            {
                if (_instance == null)
                    _instance = new CorgiORM(connectionString);
                return _instance;
            }
            set => _instance = value;
        }

        private static string connectionString;
        private DatabaseType DBType;

        protected string ConnectionString { get => connectionString; set => connectionString = value; }

        public IExecute CorgiAdd;
        public IExecute CorgiUpdate;
        public IExecute CorgiRemove;
        public IExecute CorgiGetAll;
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
                    this.CorgiGetAll = new SqlGetAll(this.ConnectionString);
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
