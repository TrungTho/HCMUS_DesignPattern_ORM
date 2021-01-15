using System;
using System.Collections.Generic;
using System.Reflection;

namespace CorgiORM
{
    class Program
    {

        static void Main(string[] args)
        {
            //var newobj = new Customer(2,"Trà Mỹ Phương", "hehe");
            var newobj = new Customer("Nguyễn Văn Hải", "11111111");

            CorgiORM.DB.Config("Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes", DatabaseType.SQL);

            // CorgiORM.DB.CorgiUpdate.executeNonQuery("customer", newobj);

            Dictionary<string, string> attributeList = new Dictionary<string, string>();
            PropertyInfo[] propertyInfo = typeof(Customer).GetProperties();
            foreach (PropertyInfo pInfo in propertyInfo)
            {
                attributeList.Add(pInfo.Name, pInfo.GetCustomAttribute<Column>().columnName);
            }
            

            ISelectQueryBuilder x = new SQLSelectBuilder<Customer>();
            Console.WriteLine(x
                .Where(Condition.And(Condition.Equal("Id", 1), new Not(Condition.Equal("Id", 1))))
                .Where(new Not(Condition.Equal("Id", 1)))
                .GroupBy("Id")
                .Having(Condition.Equal("Id",1))
                .OrderBy("Id","ASC")
                .OrderBy("ten", "ASC")
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