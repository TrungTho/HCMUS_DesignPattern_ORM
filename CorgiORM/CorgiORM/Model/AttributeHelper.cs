using System;

namespace CorgiORM.Model {
    public class AttributeHelper {
        public static string GetDataNames(Type type, string propertyName) {
            //get DataNames attributes from ${propertyName} field in model
            var attributes = type.GetProperty(propertyName).GetCustomAttributes(false);
            DataNamesAttribute property = null;
            foreach (Object prop in attributes) {
                if (prop.GetType().Name == "DataNamesAttribute") {
                    property = (DataNamesAttribute)prop;
                    break;
                }
            }

            //if existed, return list of valueNames in attribute
            if (property != null) {
                return ((DataNamesAttribute)property).ValueNames;
            }

            return "";
        }
    }
}
