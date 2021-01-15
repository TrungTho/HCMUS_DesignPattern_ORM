using System;
using System.Collections.Generic;
using System.Reflection;

namespace CorgiORM {
    class Program {

        static void Main(string[] args) {
            //var newobj = new Customer(2,"Trà Mỹ Phương", "hehe");
            //var newobj = new Customer(1,"Nguyễn Văn Hải", "11111111");
            var newobj = new Customer(21, "Nguyễn Hữu", "vinh@gmail.cnnnom");

            CorgiORM.DB.Config("Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes", DatabaseType.SQL);
            CorgiORM.DB.CorgiUpdate.executeNonQuery(newobj);


            ISelectQueryBuilder x = new SQLSelectBuilder<Customer>();
            Console.WriteLine(x.getQueryString());
            
            List<Customer> customers=CorgiORM.DB.CorgiGet.execute<Customer>(x.Where(Condition.GreaterThan("id",10)));
            //duoc ddi huhu cac

            foreach (var eee in customers)
                Console.WriteLine(eee);
            
            Console.ReadKey();
        }
    }
}
