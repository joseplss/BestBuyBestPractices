using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            //NEW DEPARTMENT
            var repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Please enter a new Department name");
            var newDepartments = Console.ReadLine();
            repo.InsertDepartment(newDepartments);
            var departments = repo.GetAllDepartments();
            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }
            //ADD NEW PRODUCT
            Console.WriteLine("----------------");
            var repoP = new DapperProductRepository(conn); //repoP object initialized
            var products = repoP.GetAllProducts();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} {p.Price} {p.CategoryID}");
            }

            Console.WriteLine("What is the name of your new products?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is the price?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the Cateogry ID?");
            var prodCat = int.Parse(Console.ReadLine());

            repoP.CreateProduct(prodName, prodPrice, prodCat);
            products = repoP.GetAllProducts();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} {p.Price} {p.CategoryID}");
            }

            // UPDATE PRODUCT PRICE
            Console.WriteLine("----------------");
            Console.WriteLine("Please enter the ProductID to update");
            var newID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter new price to update your products");
            var newPrice = double.Parse(Console.ReadLine());

            repoP.UpdateProduct(newID, newPrice);
            products = repoP.GetAllProducts();

            foreach(var p in products)
            {
                Console.WriteLine($"{p.Name} {p.Price} {p.CategoryID}");
            }

            // DELETE PRODUCT ID
            Console.WriteLine("----------------");
            Console.WriteLine("Please enter a product ID to delete");
            newID = int.Parse(Console.ReadLine());

            repoP.DeleteProduct(newID);

            foreach(var p in products)
            {
                Console.WriteLine($"{p.Name} {p.Price} {p.CategoryID}");
            }
        }
    }
}
