using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class ProductsService : IProductsService
    {
        #region -- fields--
        private static ProductsService instance;
        private List<Category> _categories;
        private List<Product> _products;
        #endregion

        #region --ctor and Singleton deisgn
        private ProductsService()
        {
            _categories = new List<Category>();
            _products = new List<Product>();
        }

        public static IProductsService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductsService();
                }
                return instance;
            }
        }

        #endregion

        public bool AddNewCategory(Category category)
        {
            _categories.Add(category);
            return true;
        }

        public bool AddNewProduct(Product product)
        {
            _products.Add(product);
            return true;
        }

        public Category GetCategory(string Id)
        {
            return _categories.FirstOrDefault(c => c.Id == Id);
        }

        public Product GetProduct(string Id)
        {
            return _products.FirstOrDefault(p => p.Id == Id);
        }

        public List<Category> GetAllCategories()
        {
            return _categories.OrderBy(c => c.Name).ToList();
        }

        public List<Category> GetSubCategories(string parentCategoryId)
        {
            return _categories.Where(c => c.ParentCategoryId == parentCategoryId).OrderBy(c => c.Name).ToList();
        }

        public List<Category> GetTopLevelCategories()
        {
            return _categories.Where(c => string.IsNullOrEmpty(c.ParentCategoryId)).OrderBy(c => c.Name).ToList();
        }

        public List<Product> GetAllProductsOfCategory(string categoryId)
        {
            return _products.Where(p => p.ParentCategoryId == categoryId).OrderBy(p => p.Price).ToList();
        }

        public bool RemoveProduct(string productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }

        public bool UpdateProduct(string productId, Product productCopyFrom)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.Name = productCopyFrom.Name;
                product.Price = productCopyFrom.Price;
                product.IsInStock = productCopyFrom.IsInStock;
                product.ParentCategoryId = productCopyFrom.ParentCategoryId;
                return true;
            }
            return false;
        }
    }
}
