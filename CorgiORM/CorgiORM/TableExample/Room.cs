using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM.TableExample
{
    [TableName("room")]
    class Room
    {
        [Column("id", isKey: true, autoincrement: true)]
        public int id { get; set; }

        [Column("name")]
        public string name { get; set; }

    }
}
