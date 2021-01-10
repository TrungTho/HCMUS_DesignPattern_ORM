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
        [Column("idphong", primaryKey : true, autoIncrement: true)]
        public int id { get; set; }

        [Column("tenphong")]
        public string name { get; set; }

    }
}
