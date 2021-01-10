using System;

namespace CorgiORM
{
    [AttributeUsage(AttributeTargets.All)]
    class Column : FlagsAttribute
    {
        public string column { get; set; }
        public bool primaryKey { get; set; }
        public bool autoIncrement { get; set; }
        public Column(string column, bool primaryKey = false, bool autoIncrement = false)
        {
            this.column = column;
            this.primaryKey = primaryKey;
            this.autoIncrement = autoIncrement;
        }
    }
}