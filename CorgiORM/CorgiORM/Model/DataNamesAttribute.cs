using System;

namespace CorgiORM.Model {
    [AttributeUsage(AttributeTargets.Property)]
    public class DataNamesAttribute : Attribute {
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
