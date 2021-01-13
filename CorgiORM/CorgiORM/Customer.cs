using DesignPattern_ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorgiORM
{
    [TableName("Customer")]
    class Customer
    {
        
        [Column("ID", isKey: true, autoincrement: true)]
        public int Id { get; set; }
        [Column("Fullname")]
        public string ten { get; set; }

        [Column("Tel")]
        public string phone {get; set;}

        public Customer(int id, string ten, string sdt)
        {
            this.Id = id;
            this.ten = ten;
            this.phone = sdt;
        }

        public Customer(string ten,string sdt)
        {
            this.ten = ten;
            this.phone = sdt;
        }

        public Customer() { }
    }
}