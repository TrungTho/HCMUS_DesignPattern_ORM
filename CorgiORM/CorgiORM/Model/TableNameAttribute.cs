using System;

namespace CorgiORM.Model {
    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute {
        protected string _tableName { get; set; }

        public string TableName {
            get {
                return _tableName;
            }
            set {
                _tableName = value;
            }
        }

        public TableNameAttribute() {
            _tableName = "";
        }

        public TableNameAttribute(string tableName) {
            _tableName = tableName;
        }
    }
}
