using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    public interface ISelectQueryBuilder
    {
        string getQueryString();
        ISelectQueryBuilder Where(string fieldName, Object value);
        ISelectQueryBuilder GroupBy(string fieldName);
        ISelectQueryBuilder Having(string condition);
        ISelectQueryBuilder OrderBy(string fieldName, string type);
    }
}
