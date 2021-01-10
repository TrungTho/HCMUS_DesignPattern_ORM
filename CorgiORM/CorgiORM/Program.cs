using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.OleDb;

namespace CorgiORM
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryDB fatoryMySQL= new FactoryMySQL();

            ConfigDB configMySQL = fatoryMySQL.CreateConnection("localhost", 3306, "company", "root", "123456");
            ParserDB parserMySQL = fatoryMySQL.CreateParser();
            ORM<Employee> orm = new ORM<Employee>(configMySQL, parserMySQL);

            //Employee employee1 = new Employee("test", "Male", "test@gmail.com", "12345", "HN", new DateTime(2020, 11, 12), 2);
            //int employee1Insert = orm.Insert(employee1).Execute();
            //Console.WriteLine(employee1);

            //int employee1Delete = orm.Delete().Where(Condition.Equal("idnhanvien",1)).Execute();
            //int employee2Delete = orm.Delete().Execute();
            //Console.WriteLine(employee2Delete);

            //int employee1Update = orm
            //    .Update()
            //    .Set("diachi", "Việt Nam")
            //    .Where(Condition.Equal("sdt", "12345"))
            //    .Execute();

            //int employee2Update = orm.Update().Execute();
            //Console.WriteLine(employee2Update);
            //Console.WriteLine(employeeList.Count());
            //foreach (Object e in employeeList)
            //{
            //    Employee employee = e as Employee;

            //    Console.WriteLine("Name: " + employee.tennhanvien);
            //    Console.WriteLine("---------------------");
            //}
            List<Object> res = orm
                .Select()
                .Where(Condition.GreaterThan("idphong",1))
                .AddColumnsReturn("tennhanvien","ten")
                .GroupBy("idphong")
                .AddProjection("tennhanvien", Aggregate.COUNT, "dem")
                .ToList();
            foreach (Object r in res)
            {
                Dictionary<string, Object> dict = r as Dictionary<string, Object>;
                Console.WriteLine("Name: " + dict["ten"]);
                Console.WriteLine("Number of students in class: " + dict["dem"]);
                Console.WriteLine("--------------------");
            }

            Console.ReadLine();


        }
    }
}
