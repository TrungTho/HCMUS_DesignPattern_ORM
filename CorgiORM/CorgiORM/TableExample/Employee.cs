using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    [TableName("employee")]
    class Employee
    {

        [Column("id", isKey: true, autoincrement: true)]
        public int id { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Column("gender")]
        public string gender { get; set; }

        [Column("address")]
        public string address { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("phone")]
        public string phone { get; set; }

        [Column("birthday")]
        public DateTime birthday { get; set; }

        [Column("room")]
        public int room { get; set; }

        public Employee() { }
    }
}
