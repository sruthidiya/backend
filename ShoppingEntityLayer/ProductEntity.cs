using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEntityLayer
{
   public class ProductEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImgId { get; set; }

    }
    public class CartEntity
    {
        public int CProductId { get; set; }
        public string CProductName { get; set; }
        public string CProductDescription { get; set; }
        public float CProductPrice { get; set; }
        public string CProductImgId { get; set; }

    }
}


