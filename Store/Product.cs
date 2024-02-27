using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Store.Enums;

namespace Store
{

    public class Product : BaseEntity
    {

        #region -- Proprites --
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }
        public string ParentCategoryId { get; set; } // the id of Parent Category, if empty it has no category.
        #endregion

        #region -- constractor --
        public Product() : base() // Empty Ctor with defualt values.
        {
            Name = "Default Product";
            Price = 0.0m;
            IsInStock = false;
            ParentCategoryId = string.Empty;
        }
        #endregion


        public override string ToString() // return Prduct properties as text
        {
            return $"Name: {Name}, Price: {Price}, IsInStock: {IsInStock}, ParentCategoryId: {ParentCategoryId}";
        }
    }
}