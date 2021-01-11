using System;

namespace CorgiORM
{
    class Program
    {
       


        static void Main(string[] args)
        {
            CorgiORM.Instance.Config("local/acb/pass", DatabaseType.SQL);
            CorgiORM.Instance.CorgiAdd.execute("user", 1);
            CorgiORM.Instance.CorgiGet.execute("customer", 2);
            CorgiORM.Instance.CorgiGetAll.execute("product", 4);
            CorgiORM.Instance.CorgiRemove.execute("Hehe", 1);

            Console.WriteLine("----------------------");

            CorgiORM.Instance.Config("10.210/dd/jafls", DatabaseType.SQL);
            CorgiORM.Instance.CorgiGet.execute("customer", 2);
            CorgiORM.Instance.CorgiGetAll.execute("product", 4);


            Console.ReadKey();
        }
    }
}