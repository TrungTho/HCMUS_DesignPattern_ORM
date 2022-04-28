<!-- ---
title: 'CorgiORM'
disqus: hackmd
--- -->

# CorgiORM - Object Relational Mapper

CorgiORM is a course project on the Design Patterns course. This is a Database Access Management (DAM) Framework (based on ADO.NET), supporting developers to work with data using objects of domain-specific classes without focusing on the underlying database tables and columns where this data is stored. In course scope, this project provides a set of simple syntaxes to connect, insert, delete, update and query with MSSQL RDBMS.  
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Sever-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white)![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)








## Table of Contents
- [Usage](#usage)  
  - [Object declaration example](#obj-declare)  
  - [Connect DB & Query example](#query-demo)
- [Used Patterns](#used)
  - [Singleton Pattern](#singleton)
  - [Factory Method Pattern](#factory)
  - [Template Method Pattern](#template)
  - [Builder Pattern](#builder)

Usage <a name = "usage"></a>
---
### Object declaration example:  <a name="obj-declare"/>

```
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
```
### Connect DB & Query example <a name = "query-demo"/>
```
namespace CorgiORM {
    class Program {

        static void Main(string[] args) {
            //Demo ADD / UPDATE / DELETE data
            //prepare an object adding to db
            var datum = new Customer(23, "Nguyễn Hữu Vinh", "vinh@gmail.com","0123456789",true);
            //conenect to db & db type
            CorgiORM.DB.Config("Server=localhost\\SqlExpress;Database=MyCompany; Trusted_connection=yes", DatabaseType.SQL);
            //add new row to db
            //CorgiORM.DB.CorgiAdd.executeNonQuery(datum);
            //update rwo to db (if exist)
            //CorgiORM.DB.CorgiUpdate.executeNonQuery(datum);
            //remove row from db (if exist)
            //CorgiORM.DB.CorgiRemove .executeNonQuery(datum);
            
            //demo QUERY data
            List<Customer> customers = new List<Customer>(); //list data after query
            ISelectQueryBuilder x = new SQLSelectBuilder<Customer>(); //query's builder
            
            //get all
            //customers = CorgiORM.DB.CorgiGet.execute<Customer>(x);
            //get all customer has id > 5
            //customers = CorgiORM.DB.CorgiGet.execute<Customer>(x.Where(Condition.GreaterThan("id",5)));
            //get all customer has 5 < id < 15
            //customers = CorgiORM.DB.CorgiGet.execute<Customer>(x.Where(Condition.GreaterThan("id",5)).Where(Condition.LessThan("id",15)));
            //get all customer has id > 5 and sort results ascending by name
            //customers = CorgiORM.DB.CorgiGet.execute<Customer>(x.Where(Condition.GreaterThan("id",5)).OrderBy("Name","ASC"));
            
            //foreach (var item in customers) Console.WriteLine(item);
            Console.ReadKey();
        }
    }
}
```

Used Patterns <a name = "used"/>
---
<div align = "center">  
  
### 1. Singleton Pattern  <a name = "singleton"/>  
![](https://i.imgur.com/etBs3gj.gif)  
![](https://i.imgur.com/b6HFY2G.gif)  

### 2. Factory Method Pattern  <a name = "factory"/>  
![](https://i.imgur.com/WYVeQ8I.gif)  
![](https://i.imgur.com/uq2vBn9.gif)  

### 3. Template Pattern  <a name = "template"/>  
![](https://i.imgur.com/XA1dK0V.gif)  
![](https://i.imgur.com/VqGuqPs.gif)  
![](https://i.imgur.com/FBQwvPk.gif)  

### 4. Builder Pattern  <a name = "builder"/>  
![](https://i.imgur.com/snLw7SD.gif)  

  </div>  
###### tags: `design-patterns` `corgi-orm`
