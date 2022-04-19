using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
                _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES (@names, @prices, @categoryIDs);",
                new { names = name, prices = price, categoryIDs = categoryID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM Products WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });
            Console.WriteLine("Product successfully deleted");
            Thread.Sleep(3000);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }

        public void UpdateProduct(int productID, double updatedPrice)
        {
            _connection.Execute("UPDATE products SET Price = @updateP WHERE ProductID = @PID;",
                new { updateP = updatedPrice, PID = productID });

            Console.WriteLine("Product has successfully updated");
            Thread.Sleep(3000);
        }
    }
}
