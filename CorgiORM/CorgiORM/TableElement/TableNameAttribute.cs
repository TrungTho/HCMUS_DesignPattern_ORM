using System;

namespace CorgiORM
{
    [AttributeUsage(AttributeTargets.All)]
    class TableName : FlagsAttribute
    {
        public string table { get; set; }
        public TableName(string tableName)
        {
            this.table = tableName;
        }
    }
}