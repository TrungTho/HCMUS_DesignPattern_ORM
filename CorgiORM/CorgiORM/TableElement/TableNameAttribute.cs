using System;

namespace CorgiORM
{
    [AttributeUsage(AttributeTargets.All)]
    class TableName : FlagsAttribute
    {
        public string tableName { get; set; }
        public TableName(string name)
        {
            tableName = name;
        }
    }
}