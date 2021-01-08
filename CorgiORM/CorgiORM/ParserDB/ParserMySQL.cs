﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    class ParserMySQL : ParserDB
    {
        public override string ParseDeleteQuery(string table, string where)
        {
            throw new NotImplementedException();
        }

        public override string ParseInsertQuery(string table, Dictionary<string, string> values)
        {
            throw new NotImplementedException();
        }

        public override string ParseSelectQuery(string table, string projections, string where, string groupBy = "", string having = "", string orderBy = "")
        {
            throw new NotImplementedException();
        }

        public override string ParseUpdateQuery(string table, Dictionary<string, string> setValues, string where)
        {
            throw new NotImplementedException();
        }

        public override string ParseValue(object obj, Type type)
        {
            if (type == typeof(string))
                return "\"" + obj.ToString() + "\"";
            else if (type == typeof(DateTime))
            {
                return "\"" + ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
            }
            return obj.ToString();
        }
    }
}
