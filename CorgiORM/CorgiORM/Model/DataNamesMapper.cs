using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CorgiORM.Model {
    public class DataNamesMapper<TEntity> where TEntity : new() {
        //get all custom attribute (DataNames attribute) from TEntity
        private List<PropertyInfo> GetDataNamesAttributeFields<TEntity>() {
            //Get list of properties of TEntity
            PropertyInfo[] Allproperties = (typeof(TEntity)).GetProperties();

            //Get field with datanames attribute only
            List<PropertyInfo> properties = new List<PropertyInfo>();
            foreach (PropertyInfo prop in Allproperties) {
                object[] customAttr = prop.GetCustomAttributes(typeof(DataNamesAttribute), true);
                if (customAttr.Length > 0) {
                    properties.Add(prop);
                }
            }

            return properties;
        }

        //map datarơ ==> an entity object
        public TEntity Map(DataRow row) {
            //Get field with datanames attribute only
            List<PropertyInfo> properties = GetDataNamesAttributeFields<TEntity>();

            TEntity entity = new TEntity();
            //for each field => set value with column has name equal to field valueName
            foreach (var prop in properties) {
                PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
            }
            return entity;
        }

        //map dataset ==> list of entity object
        public IEnumerable<TEntity> Map(DataTable table) {
            //Get field with datanames attribute only
            List<PropertyInfo> properties = GetDataNamesAttributeFields<TEntity>();
            //create a list of TEntity
            List<TEntity> entities = new List<TEntity>();

            foreach (DataRow row in table.Rows) {
                //create a corresponding TEntity for each row in table
                TEntity entity = new TEntity();
                //for each field declared in TEntity (user-defined model) map it with PropertyMapHelper
                foreach (var prop in properties) {
                    //for each field => set value with column has name equal to field valueName
                    PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
                }
                //add object-transformed row to list
                entities.Add(entity);
            }

            return entities;
        }
    }
}
