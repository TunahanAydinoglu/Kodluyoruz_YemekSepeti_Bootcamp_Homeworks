using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Week5.DapperAPI.Models;

namespace Week5.DapperAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DapperSampleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DapperSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void checkConnection(IDbConnection db)
        {
            if (db.State != ConnectionState.Open)
            {
                db.Open();
            }
        }
        public IActionResult DapperSelect()
        {
            /*
             Databasedeki Person.Person tablosundaki bütün verileri listelemek için bir sql komutu oluşturdum ve Query methodu yardımıyla 
            Databasede sql komutumu çalıştırmış oldum. Geriye dönen datayı Person classıma map ettim ve kullanıcıların ıd, firtname, lastname datalarını
            kullanıma hazır şekilde databaseden çekmiş oldum.
            Sql komutunun profilerdaki hali : select * from [Person].[Person]
             */
            IEnumerable<Person> persons;
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = "select * from [Person].[Person]";

                persons = db.Query<Person>(sql);
            }
            return Ok(persons);
        }

        public IActionResult DapperInsert()
        {
            /*
                Databaseimde test için dbo.TestPerson adında bir tablo oluşturdum.
            insert into komutuyla sqlde ekleme işlemleri yapabilecek bir sql komutu yazdım ve values tarafında göndereceğim parametleri belirttim.
            TestPerson classımdan bir testData nesnesi oluşturdum.
            dapperın execute komutuna sql sorgumu ve parametre olarak nesnemi gönderdim ve dapper nesnemin parametleriyle sqldeki parametleri eşleyip 
            databasede insert işlemini gerçekleştirdi .
            sql tarafında çalışan komut : exec sp_executesql N'insert into dbo.TestPerson (Name, Surname) values (@Name, @Surname);',
            N'@Name nvarchar(4000),@Surname nvarchar(4000)',@Name=N'Tunahan',@Surname=N'Aydinoglu'
             */

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"insert into dbo.TestPerson (Name, Surname) values (@Name, @Surname);";

                TestPerson testData = new TestPerson { Name = "Tunahan", Surname = "Aydinoglu" };
                var affected = db.Execute(sql, testData);
            }
            return Ok();
        }

        public IActionResult DapperUpdate()
        {
            /*
             yazdigimiz sql komutuyle update islemi hedefliyoruz şart olarak ıdsi gönderdiğimiz parametreyle eşleşen bir person varsa onun Name alanını 
            bizim parametre olarak gönderdiğimiz name alanıyla güncellemesini istiyoruz.
            Yine dapperın Execute methoduna yazdığımız sql sorgusunu ve parametrelerimizi gönderiyoruz.
            Bu sefer many parameter yolladık birden çok parametre yolladığımız için dapper aynı komutu dizideki herbir eleman için tekrar tekrar çalıştırıyor.
            Database tarafında çalışan komut örneği :              
             exec sp_executesql N'Update dbo.TestPerson Set Name = @Name where Id=@Id ',N'@Id int,@Name nvarchar(4000)',@Id=2,@Name=N'Tun'
             */
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"Update dbo.TestPerson Set Name = @Name where Id=@Id ";

                var updatePersons = new[] {
                    new {Id=1 , Name="Kerem"},
                    new {Id=2 , Name="Tun"}
                };

                var affected = db.Execute(sql, updatePersons);
            }

            return Ok();
        }

        public IActionResult DapperDelete()
        {
            /*
                delete sql komutumu yazdım  ve dapperın execute methoduna gonderiyoruz ve paremetre olarak beklediğimiz Id için bir obje
            gönderiyoruz dapper bizim için databasede sorgumuzda gönderdiğimiz parametreleri eşliyor ve karşılığında buldu veri üzerinde sorugumuzda olan
            delete komunutu çalıştırıyor.
            sql tarafında çalışan sorgumuz : exec sp_executesql N'Delete from dbo.TestPerson where Id=@Id',N'@Id int',@Id=3
             */
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"Delete from dbo.TestPerson where Id=@Id";
                var affected = db.Execute(sql,
                    new { Id = 3 }
                );
            }
            return Ok();
        }

        public IActionResult DapperDeleteInQuery()
        {
            /*
             * delete sql komutumu yazdım  ve dapperın execute methoduna gonderiyoruz ve paremetre olarak beklediğimiz Id için bir obje
            gönderiyoruz dapper bizim için databasede sorgumuzda gönderdiğimiz parametreleri eşliyor ve karşılığında buldu veri üzerinde sorugumuzda olan
            delete komunutu çalıştırıyor.
            sql tarafında çalışan sorgumuz :
                  exec sp_executesql N'Delete from dbo.TestPerson where Id=@Id',N'@Id int',@Id=4
            */
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"Delete from dbo.TestPerson where Id=@Id";
                var data = db.Query(sql,
                    new { Id = 4 }
                );
            }

            return Ok();
        }

        public IActionResult DapperSP()
        {
            /*
                Databasede SelectTestPersons adinda bir StoredProcedure olusturdum ve Testperson tabloma select sorgusu atan bir procedure.
                sql olarak procedure adimi yazdim ve dapper execute methoduna yolladim.
                herhangi bir parametre girmedigim icin null gonderdi.
                gonderdigim sqli dapperin StoredProcedure oldugunu anlamasi icin commentType propertisinde belirttim.
                Sql tarafinda calisan komut : 
                        exec dbo.SelectTestPersons
             */

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = "dbo.SelectTestPersons";
                db.Execute(sql, null, commandType: CommandType.StoredProcedure);
            }
            return Ok();
        }

        public IActionResult DapperTransaction()
        {
            /*
             Database'e birden cok islem yaptiracagimiz zaman ve bir islemde hata alinca digerlerininde kaydinin iptalinin gerekli oldugu durumlarda  
            transaction kullanabiliriz.
            burda sirayla iki adet insert islemi yaptik ve hatasiz calismalari durumunda transaction commit edilip kaydediliyor.
            sql tarafina giden sorgularimiz : 
             exec sp_executesql N'insert into dbo.TestPerson (Name,Surname) values (@Name,@Surname);',N'@Name nvarchar(4000),@Surname nvarchar(4000)',@Name=N'Deneme name',@Surname=N'Surname'
             exec sp_executesql N'Insert into [Production].[ScrapReason] (Name, ModifiedDate) values (@Name, @ModifiedDate);',N'@ModifiedDate datetime,@Name nvarchar(4000)',@ModifiedDate='2021-02-26 17:
             */

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                using (var transaction = db.BeginTransaction())
                {

                    string sql = @"insert into dbo.TestPerson (Name,Surname) values (@Name,@Surname);";

                    TestPerson testPerson = new TestPerson { Name = "Deneme name", Surname = "Surname" };
                    db.Execute(sql, testPerson, transaction);


                    ScrapReason scrapReason = new ScrapReason { Name = "Scrap added", ModifiedDate = DateTime.Now };
                    sql = @"Insert into [Production].[ScrapReason] (Name, ModifiedDate) values (@Name, @ModifiedDate);";
                    db.Execute(sql, scrapReason, transaction);

                    transaction.Commit();
                }
            }

            return Ok();
        }
        public IActionResult DapperResultMapping()
        {
            /*
                sql sorgumuzu olusturdum.
                dapperin queryfirtordefault methodunu kullanarak donen sonuclarin ilkini donus degeri olarak almis oldum.
                sql tarafina giden komut :  select AddressLine1,City,PostalCode from [Person].[Address]
                    
             */
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);
                string sql = "select AddressLine1,City,PostalCode from [Person].[Address]";

                var data = db.QueryFirstOrDefault(sql);

                return Ok(data);
            }

        }
        public IActionResult DapperOneToOne()
        {
            /*
             sql sorgusunda inner join kullanarak iki tabloyu birbirine esleyecegimiz paremetleri belirttim.
            querye eslenecek classlari type olarak gectim.
            order ve employee tablolarini virtual ile birlestirdim.
            sql tarafina giden komut : 
                select * from [Purchasing].[PurchaseOrderHeader] as Pur Inner Join [HumanResources].[Employee] as Emp ON Pur.EmployeeID = Emp.BusinessEntityID;
             */
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);
                string sql = "select * from [Purchasing].[PurchaseOrderHeader] as Pur Inner Join [HumanResources].[Employee] as Emp ON Pur.EmployeeID = Emp.BusinessEntityID;";

                var data = db.Query<OrderHeader, Employee, OrderHeader>(
                        sql,
                        (order, employee) =>
                        {
                            order.Employee = employee;
                            return order;
                        },
                        splitOn: "EmployeeID"
                        ).Distinct().ToList();
                return Ok(data);
            }
        }
        public IActionResult DapperOneToMany()
        {
            /*
             One to many iliski kurabilmek icin inner join sql sorgusu yazdim.
            categoryler ve subcategorileri beraber listeleyebilmek icin bir dictionary olusturdum.
            queryde maplenmesini istedigimiz typeleri belirtip bir function icinde eslestirmeleri belirtip mapleme islemini tamamlamis oluyoruz.
            cikan sonucu listeye cevirip return ediyoruz.
            sql tarafina giden komut : 
                select * from [Production].[ProductCategory] as Cat Inner Join [Production].[ProductSubcategory] as Sub ON Cat.ProductCategoryID = Sub.ProductCategoryID;
             */
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);
                string sql = "select * from [Production].[ProductCategory] as Cat Inner Join [Production].[ProductSubcategory] as Sub ON Cat.ProductCategoryID = Sub.ProductCategoryID;";

                var categoryDictionary = new Dictionary<int, ProductCategory>();

                var data = db.Query<ProductCategory, ProductSubcategory, ProductCategory>(sql,
                    (category, subCategory) =>
                    {
                        ProductCategory categoryData;
                        if (!categoryDictionary.TryGetValue(category.ProductCategoryID, out categoryData))
                        {
                            categoryData = category;
                            categoryData.ProductSubcategories = new List<ProductSubcategory>();
                            categoryDictionary.Add(categoryData.ProductCategoryID, categoryData);
                        }
                        categoryData.ProductSubcategories.Add(subCategory);
                        return categoryData;
                    },
                    splitOn: "ProductSubcategoryID"
                ).Distinct().ToList();

                return Ok(data);
            }
        }
        public IActionResult DapperMultipleQueryMapping()
        {
            /*
                Multiple query methodu inner join islemleri gibi islemlerde kullanabilecegimiz bir method diyebilirim.
                tek bir sorguda iki ayri tabloyu birlestirmek yerine iki ayri sorguyla datalari alip resultta joinliyoruz.
                multiple icine sorgu sonuclarini aliyoruz;
                read ile typesafe okuma islemi gerceklestirip sorgu sonucunda bekledigimiz datalari yerlestiriyoruz.
                bunun icin 2 adet model olusturup product modelinin icinde virtual list olarak ProductCostHistory modelini tutuyorum.
                burdada ikinci sorgumun sonucunu product modelin icindeki listeye ekliyoruz.
             */

            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"select * from [Production].[Product] where ProductId = @ProductID; Select * from [Production].[ProductCostHistory] where ProductId = @ProductID;";
                Product product;
                using (var multiple = db.QueryMultiple(sql, new { ProductID = 711 }))
                {
                    product = multiple.Read<Product>().First();
                    product.ProductCosts = multiple.Read<ProductCostHistory>().ToList();
                }
                return Ok(product);
            }

        }




    }
}
