// ﻿using DesignPattern_ORM;
// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace CorgiORM
// {
//     [TableName("Customer")]
//     class Customer
//     {
        
//         [Column("ID", isKey: true, autoincrement: true)]
//         public int Id { get; set; }
//         [Column("Fullname")]
//         public string ten { get; set; }

//         [Column("Tel")]
//         public string phone {get; set;}

//         public Customer(int id, string ten, string sdt)
//         {
//             this.Id = id;
//             this.ten = ten;
//             this.phone = sdt;
//         }

//         public Customer(string ten,string sdt)
//         {
//             this.ten = ten;
//             this.phone = sdt;
//         }

//         public Customer() { }
//     }
// }
﻿using CorgiORM.Model;
using System;

namespace CorgiORM {
    [TableName("Customers")]
    public class Customer {
        [DataNames("id")]
        public int id { get; set; }

        [DataNames("name")]
        public string name { get; set; }

        [DataNames("email")]
        public string email { get; set; }

        [DataNames("tel")]
        public string tel { get; set; }

        [DataNames("male")]
        public bool male { get; set; }

        [DataNames("dob")]
        public DateTime? dob { get; set; }

        public Customer(int id, string name, string email) {
            this.id = id;
            this.name = name;
            this.email = email;
        }
    }
}
