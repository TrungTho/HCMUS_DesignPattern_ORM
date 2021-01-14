using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CorgiORM.Model {
    public class DataNamesMapper<TEntity> where TEntity : new() {
        /*public TEntity Map(DataRow row) {
            var columnNames = row.Table.Columns.Cast<DataColumn>()
                .Select(x => x.ColumnName).ToList();

            var properties = (typeof(TEntity)).GetProperties().Where(x =>
            x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any()).ToList();

            TEntity entity = new TEntity();
            foreach (var prop in properties) {
                PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
            }
            return entity;
        }*/

        public List<TEntity> GetTableSchema(DataSet data, string DBName) {
            List<TEntity> objectList = new List<TEntity>();

            foreach (DataTable table in data.Tables) {
                if (table.TableName == DBName) {
                    objectList = (List<TEntity>)Map(table);
                }
            }

            return objectList;
        }

        public IEnumerable<TEntity> Map(DataTable table) {

            //list all TEntity public field
            var allProperties = (typeof(TEntity)).GetProperties();

            //choose TEntity public field applied DataNames attribute (return PropertyInfo[])
            List<PropertyInfo> properties = new List<PropertyInfo>();
            foreach (PropertyInfo prop in allProperties) {
                if (Attribute.IsDefined(prop, typeof(DataNamesAttribute))) {
                    properties.Add(prop);
                };
            }

            //create a list of TEntity
            List<TEntity> entities = new List<TEntity>();

            foreach (DataRow row in table.Rows) {
                //create a corresponding TEntity for each row in table
                TEntity entity = new TEntity();
                //for each field declared in TEntity (user-defined model) map it with PropertyMapHelper
                foreach (var prop in properties) {
                    //fill entity fields with row data
                    PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
                }
                //add object-transformed row to list
                entities.Add(entity);
            }

            return entities;
        }
    }
}
