using System;
using System.Reflection;

namespace CorgiORM.Model {
    public class AttributeHelper {
        public static string GetDataNames(Type type, string propertyName) {
            //get column name in DataNameAttribute from ${propertyName} field in model
            var prop = type.GetProperty(propertyName).
                GetCustomAttribute(typeof(DataNamesAttribute), false);
            //if existed, return column name
            if (prop != null) {
                DataNamesAttribute attribute = (DataNamesAttribute)prop;
                return attribute.ValueNames;
            }
            return "";
        }

        //Get table name in TableNameAttribute from TEntity class (model)
        public static string GetTableName<TEntity>() where TEntity : class, new() {
            //Get TableNameAttribute
            var prop = (typeof(TEntity)).GetCustomAttribute(typeof(TableNameAttribute), false);
            //If existed, return table name
            if (prop != null) {
                TableNameAttribute attribute = (TableNameAttribute)prop;
                return attribute.TableName;
            }
            return "";

        }
    }
}
