using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); //stubbed out
        public void CreateProduct(string name, double price, int categoryID);
        public void UpdateProduct(int productID, double updatedPrice);
        public void DeleteProduct(int productID);
    }
}
