using System;
using System.Collections.Generic;
using System.Reflection;

namespace CorgiORM {
    class Program {

        static void Main(string[] args) {
            //var newobj = new Customer(2,"Trà Mỹ Phương", "hehe");
            var newobj = new Customer(1,"Nguyễn Văn Hải", "11111111");
            // var newobj = new Customer(23, "Nguyễn Hữu Vinh", "vinh@gmail.com");

            CorgiORM.DB.Config("Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes", DatabaseType.SQL);
            //CorgiORM.DB.CorgiAdd.executeNonQuery("Customers", newobj);

            //CorgiORM.DB.CorgiRemove.executeNonQuery("Customer", newobj);

            // CorgiORM.DB.CorgiUpdate.executeNonQuery("customer", newobj);

            //Dictionary<string, string> attributeList = new Dictionary<string, string>();
            //PropertyInfo[] propertyInfo = typeof(Customer).GetProperties();
            //foreach (PropertyInfo pInfo in propertyInfo)
            //{
            //    attributeList.Add(pInfo.Name, pInfo.GetCustomAttribute<Column>().columnName);
            //}


            ISelectQueryBuilder x = new SQLSelectBuilder<Customer>();
            Console.WriteLine(x
                .Where(Condition.And(Condition.Equal("id", 1), new Not(Condition.Equal("id", 1))))
                .Where(new Not(Condition.Equal("id", 1)))
                .GroupBy("id")
                .Having(Condition.Equal("id", 1))
                .OrderBy("id", "ASC")
                .OrderBy("name", "ASC")
                .getQueryString());
            //Console.WriteLine(Condition.Equal("id", 1).parseDataToString());
            //CorgiORM.DB.CorgiAdd.executeNonQuery("customer", newobj);

            //List<Tuple<string, Object>> wherecondition = new List<Tuple<string, object>>();
            //wherecondition.Add(Tuple.Create("ID",(Object)2));

            //CorgiORM.DB.CorgiGet


            Console.ReadKey();
        }
    }
}
