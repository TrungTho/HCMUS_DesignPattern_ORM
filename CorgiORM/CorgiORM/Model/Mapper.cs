using System.Collections.Generic;
using System.Data;

namespace CorgiORM.Model {
    public class Mapper {

        public static List<TEntity> MapDataWithList<TEntity>(DataSet data, string DBName) where TEntity : new() {
            List<TEntity> objectList = new List<TEntity>();
            DataNamesMapper<TEntity> mapper = new DataNamesMapper<TEntity>();

            foreach (DataTable table in data.Tables) {
                if (table.TableName == DBName) {
                    objectList = (List<TEntity>)mapper.Map(table);
                }
            }

            return objectList;
        }

        public static TEntity MapDataWithObject<TEntity>(DataRow row) where TEntity : new() {
            TEntity Object = new TEntity();
            DataNamesMapper<TEntity> mapper = new DataNamesMapper<TEntity>();
            Object = mapper.Map(row);
            return Object;
        }
    }
}
