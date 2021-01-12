﻿using System;

namespace CorgiORM
{
    class Program
    {
        class Customer
        {
            public int ID { get; set; }
            public string Fullname { get; set; }
            public string Tel { get; set; }

            public override string ToString()
            {
                return $"{ID} - {Fullname} - {Tel}";
            }

            public Customer(int id, string name, string tel)
            {
                this.ID = id;
                this.Fullname = name;
                this.Tel = tel;
            }

            public Customer(string name, string tel)
            {
                this.Fullname = name;
                this.Tel = tel;
            }
        }

        static void Main(string[] args)
        {
            var newobj = new Customer(1,"Nguyễn Văn Hải", "456");

            CorgiORM.DB.Config("Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes", DatabaseType.SQL);

            CorgiORM.DB.CorgiUpdate.executeNonQuery("customer", newobj);


            Console.ReadKey();
        }
    }
}