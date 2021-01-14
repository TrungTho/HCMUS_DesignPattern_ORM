using System;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace CorgiORM.Model {
    public static class PropertyMapHelper {
        public static void Map(Type type, DataRow row, PropertyInfo prop, object entity) {
            string columnName = AttributeHelper.GetDataNames(type, prop.Name);

            //for each _valueNames in attribute
            //if not null and equal with any table column
            if (!String.IsNullOrWhiteSpace(columnName) &&
                row.Table.Columns.Contains(columnName)) {
                //get that column value from current row
                var propertyValue = row[columnName];
                //check if that value not NULL
                if (propertyValue != DBNull.Value) {
                    //parse value with fit-type for each field
                    ParsePrimitive(prop, entity, row[columnName]);
                }
            }
        }

        private static void ParsePrimitive(PropertyInfo prop, object entity, object value) {
            //check if property type = string and set string-type value
            if (prop.PropertyType == typeof(string)) {
                //set fit-value type for ${prop} property in entity
                prop.SetValue(entity, value.ToString().Trim(), null);
            }
            else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?)) {
                if (value == null) {
                    prop.SetValue(entity, null, null);
                }
                else {
                    prop.SetValue(entity, ParseBoolean(value.ToString()), null);
                }
            }
            else if (prop.PropertyType == typeof(long)) {
                prop.SetValue(entity, long.Parse(value.ToString()), null);
            }
            else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?)) {
                if (value == null) {
                    prop.SetValue(entity, null, null);
                }
                else {
                    prop.SetValue(entity, int.Parse(value.ToString()), null);
                }
            }
            else if (prop.PropertyType == typeof(decimal)) {
                prop.SetValue(entity, decimal.Parse(value.ToString()), null);
            }
            else if (prop.PropertyType == typeof(double) || prop.PropertyType == typeof(double?)) {
                double number;
                bool isValid = double.TryParse(value.ToString(), out number);
                if (isValid) {
                    prop.SetValue(entity, double.Parse(value.ToString()), null);
                }
            }
            else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(Nullable<DateTime>)) {
                DateTime date;
                bool isValid = DateTime.TryParse(value.ToString(), out date);
                if (isValid) {
                    prop.SetValue(entity, date, null);
                }
                else {
                    isValid = DateTime.TryParseExact(value.ToString(), "MMddyyyy", new CultureInfo("en-US"), DateTimeStyles.AssumeLocal, out date);
                    if (isValid) {
                        prop.SetValue(entity, date, null);
                    }
                }
            }
            else if (prop.PropertyType == typeof(Guid)) {
                Guid guid;
                bool isValid = Guid.TryParse(value.ToString(), out guid);
                if (isValid) {
                    prop.SetValue(entity, guid, null);
                }
                else {
                    //D = format for guid 32 digits with hyphens
                    isValid = Guid.TryParseExact(value.ToString(), "D", out guid);
                    if (isValid) {
                        prop.SetValue(entity, guid, null);
                    }
                }
            }
        }

        public static bool ParseBoolean(object value) {
            if (value == null || value == DBNull.Value) return false;

            switch (value.ToString().ToLowerInvariant()) {
                case "1":
                case "y":
                case "yes":
                case "true":
                    return true;

                case "0":
                case "n":
                case "no":
                case "false":
                    return false;
            }

            return false;
        }
    }
}
