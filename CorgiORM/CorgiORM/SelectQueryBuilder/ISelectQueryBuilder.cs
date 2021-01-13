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
        ISelectQueryBuilder Where(Condition condition);
        ISelectQueryBuilder GroupBy(string fieldName);
        ISelectQueryBuilder Having(Condition condition);
        ISelectQueryBuilder OrderBy(string fieldName, string type);
    }
}
