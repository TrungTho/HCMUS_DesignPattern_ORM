using System;
using System.Collections.Generic;
using System.Reflection;

namespace CorgiORM {
    class Program {

        static void Main(string[] args) {
            var newobj = new Customer(21, "Nguyễn Hữu", "vinh@gmail.cnnnom");

            CorgiORM.DB.Config("Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes", DatabaseType.SQL);

            //CorgiORM.DB.CorgiUpdate.executeNonQuery(newobj);

            ISelectQueryBuilder x = new SQLSelectBuilder<Customer>();
            
            List<Customer> customers=CorgiORM.DB.CorgiGet.execute<Customer>(x.Where(Condition.GreaterThan("id",10)).OrderBy("name","ASC"));
            Console.WriteLine(x.getQueryString());

            Customer customer= CorgiORM.DB.CorgiGet.executeGetFirst<Customer>(x.Where(Condition.GreaterThan("id", 10)));


            //duoc ddi huhu cac
            foreach (var eee in customers)
                Console.WriteLine(eee);

            Console.WriteLine("-----------------------");
            Console.WriteLine(customer);
            
            Console.ReadKey();
        }
    }
}
