using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IProductsService
    {
        bool AddNewCategory(Category category);
        bool AddNewProduct(Product product);
        Category GetCategory(string Id);
        Product GetProduct(string Id);
        List<Category> GetAllCategories(); // Ordered by Name
        List<Category> GetSubCategories(string parentCategoryId); // Ordered by Name
        List<Category> GetTopLevelCategories(); // Ordered by Name
        List<Product> GetAllProductsOfCategory(string categoryId); // Ordered by Price
        bool RemoveProduct(string productId);
        bool UpdateProduct(string productId, Product productCopyFrom);
    }
}