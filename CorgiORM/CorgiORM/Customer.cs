using CorgiORM.Model;
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
