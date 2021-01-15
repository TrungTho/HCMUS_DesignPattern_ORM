using System;

namespace CorgiORM {
    class Program {

        static void Main(string[] args) {
            //var newobj = new Customer(2,"Trà Mỹ Phương", "hehe");
            var newobj = new Customer(23, "Nguyễn Hữu Vinh", "vinh@gmail.com");

            CorgiORM.DB.Config("Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes", DatabaseType.SQL);
            CorgiORM.DB.CorgiAdd.executeNonQuery("Customers", newobj);

            //CorgiORM.DB.CorgiRemove.executeNonQuery("Customer", newobj);

            //CorgiORM.DB.CorgiGet.execute("");


            //CorgiORM.DB.CorgiGet


            Console.ReadKey();
        }
    }
}
