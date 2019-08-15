using System;
using System.Collections.Generic;

namespace product_manager.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
