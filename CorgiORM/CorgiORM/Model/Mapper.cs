using System.Collections.Generic;
using System.Data;

namespace CorgiORM.Model {
    public class Mapper {
        //map dataset with list of TEntity
        public static List<TEntity> MapDataWithList<TEntity>(DataSet data) where TEntity : class, new() {
            //required class for mapping TEntity and list for result
            List<TEntity> objectList = new List<TEntity>();
            DataNamesMapper<TEntity> mapper = new DataNamesMapper<TEntity>();
            //get table name from table name attribute
            string tableName = AttributeHelper.GetTableName<TEntity>();
            //find needed table and map data
            foreach (DataTable table in data.Tables) {
                if (table.TableName == tableName) {
                    objectList = (List<TEntity>)mapper.Map(table);
                }
            }

            return objectList;
        }

        //map datarow with model TEntity
        public static TEntity MapDataWithObject<TEntity>(DataRow row) where TEntity : new() {
            //required class for mapping TEntity
            DataNamesMapper<TEntity> mapper = new DataNamesMapper<TEntity>();
            //map object with row data
            TEntity Object = mapper.Map(row);
            return Object;
        }
    }
}
