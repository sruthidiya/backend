using ShoppingDataLayer;
using ShoppingEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBussinessLayer
{
    public class CartBussinessLayer
    {
        public List<CartEntity> GetCProductDetailById(int CProductId)
        {
            CartDataAccesLayer cartDataAccess = new CartDataAccesLayer();
            return cartDataAccess.GetCProductDetailsById(CProductId);
        }

        public List<CartEntity> GetCProductDetail()
        {
            CartDataAccesLayer cartDataAccess = new CartDataAccesLayer();
            return cartDataAccess.GetCProductDetails();
        }

        public bool InsertCProduct(CartEntity Cart)
        {
            CartDataAccesLayer cartDataAccess = new CartDataAccesLayer();
            return cartDataAccess.InsertCProduct(Cart);
        }

        public bool UpdateCProduct(int CProductId, CartEntity Cart)
        {
            CartDataAccesLayer cartDataAccess = new CartDataAccesLayer();
            return cartDataAccess.UpdateCProduct(CProductId, Cart);
        }

        public bool DeleteCProduct(int CProductId)
        {
            CartDataAccesLayer cartDataAccess = new CartDataAccesLayer();
            return cartDataAccess.DeleteCProduct(CProductId);
        }
    }
}
    

