using CorgiORM.Model;
using System;

namespace CorgiORM {
    [TableName("Products")]
    class Product {
        [DataNames("id")]
        public string id { get; set; }

        [DataNames("name")]
        public string name { get; set; }

        [DataNames("quantity")]
        public string count { get; set; }

        [DataNames("rating")]
        public double rate { get; set; }

        [DataNames("price")]
        public double price { get; set; }

        [DataNames("importAt")]
        public DateTime importAt { get; set; }

        [DataNames("exportAt")]
        public DateTime exportAt { get; set; }

        [DataNames("isChecked")]
        public bool isChecked { get; set; }
    }
}
