using System;
using System.Collections.Generic;
using System.Reflection;

namespace CorgiORM {
    class Program {

        static void Main(string[] args) {

            var datum = new Customer(23, "Nguyễn Hữu Vinh", "vinh@gmail.com","0123456789",true);

            CorgiORM.DB.Config("Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes", DatabaseType.SQL);

            //CorgiORM.DB.CorgiAdd.executeNonQuery(datum);

            //CorgiORM.DB.CorgiUpdate.executeNonQuery(datum);

            //CorgiORM.DB.CorgiRemove .executeNonQuery(datum);

            List<Customer> customers = new List<Customer>();
            ISelectQueryBuilder x = new SQLSelectBuilder<Customer>();

            //get all
            //customers = CorgiORM.DB.CorgiGet.execute<Customer>(x);
            

            customers = CorgiORM.DB.CorgiGet.execute<Customer>(x.Where(Condition.GreaterThan("id",5)));


            //customers = CorgiORM.DB.CorgiGet.execute<Customer>(x.Where(Condition.GreaterThan("id",5)).Where(Condition.LessThan("id",15)));

            //customers = CorgiORM.DB.CorgiGet.execute<Customer>(x.Where(Condition.GreaterThan("id",5)).OrderBy("Name","ASC"));

            //foreach (var item in customers) Console.WriteLine(item);
            
            
            Console.ReadKey();
        }
    }
}
