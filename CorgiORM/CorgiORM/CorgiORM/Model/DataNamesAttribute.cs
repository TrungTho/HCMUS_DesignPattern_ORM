using System;

namespace CorgiORM {
    //attribute for class property only
    [AttributeUsage(AttributeTargets.Property)]
    public class DataNamesAttribute : Attribute {
        //_valueNames contain column name in table that match this class property
        protected string _valueNames { get; set; }

        public string ValueNames {
            get {
                return _valueNames;
            }
            set {
                _valueNames = value;
            }
        }

        public DataNamesAttribute() {
            _valueNames = "";
        }

        public DataNamesAttribute(string valueNames) {
            _valueNames = valueNames;
        }
    }
}
