using System;

namespace CorgiORM.Model {
    //attribute for class only
    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute {
        //_tableName contain table name that match this class (model)
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
