﻿using System;

namespace CorgiORM
{
    [AttributeUsage(AttributeTargets.All)]
    class Column : FlagsAttribute
    {
        public string columnName { get; set; }
        public bool isKey { get; set; }
        public bool autoincrement { get; set; }
        public Column(string column, bool isKey = false, bool autoincrement = false)
        {
            this.columnName = column;
            this.isKey = isKey;
            this.autoincrement = autoincrement;
        }
    }
}