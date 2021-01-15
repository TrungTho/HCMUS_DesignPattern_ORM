using System.Collections.Generic;
using System.Data;

namespace CorgiORM.Model {
    public class Mapper {

        public static List<TEntity> MapDataWithList<TEntity>(DataSet data) where TEntity : class, new() {
            List<TEntity> objectList = new List<TEntity>();
            DataNamesMapper<TEntity> mapper = new DataNamesMapper<TEntity>();

            string tableName = AttributeHelper.GetTableName<TEntity>();

            foreach (DataTable table in data.Tables) {
                if (table.TableName == tableName) {
                    objectList = (List<TEntity>)mapper.Map(table);
                }
            }

            return objectList;
        }

        public static TEntity MapDataWithObject<TEntity>(DataRow row) where TEntity : new() {
            DataNamesMapper<TEntity> mapper = new DataNamesMapper<TEntity>();
            TEntity Object = mapper.Map(row);
            return Object;
        }
    }
}
