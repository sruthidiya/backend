using ShoppingDataLayer;
using ShoppingEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBussinessLayer
{
    public class ProductBussinessLayer
    {
        public List<ProductEntity> GetProductDetailById(int ProductId)
        {
            ProductDataAccessLayer productDataAccess = new ProductDataAccessLayer();
            return productDataAccess.GetProductDetailsById(ProductId);
        }

        public List<ProductEntity> GetProductDetail()
        {
            ProductDataAccessLayer productDataAccess = new ProductDataAccessLayer();
            return productDataAccess.GetProductDetails();
        }

        public bool InsertProduct(ProductEntity Product)
        {
            ProductDataAccessLayer productDataAccess = new ProductDataAccessLayer();
            return productDataAccess.InsertProduct(Product);
        }

        public bool UpdateProduct(int ProductId, ProductEntity Product)
        {
            ProductDataAccessLayer productDataAccess = new ProductDataAccessLayer();
            return productDataAccess.UpdateProduct(ProductId, Product);
        }

        public bool DeleteProduct(int ProductId)
        {
            ProductDataAccessLayer productDataAccess = new ProductDataAccessLayer();
            return productDataAccess.DeleteProduct(ProductId);
        }
    }
}