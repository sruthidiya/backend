using ShoppingEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataLayer
{
   public class CartDataAccesLayer
    {
        trainingDBEntities db = new trainingDBEntities();
        public List<CartEntity> GetCProductDetailsById(int CProductId)
        {
            var data = (from Cart in db.Carts
                        where Cart.CProductId == CProductId
                        select new CartEntity()
                        {
                            CProductId = Cart.CProductId,
                            CProductName = Cart.CProductName,
                            CProductDescription = Cart.CProductDescription,
                            CProductPrice = (float)Cart.CProductPrice,
                            CProductImgId = Cart.CProductImgId
                        }).ToList();
            return data;
        }
        public List<CartEntity> GetCProductDetails()
        {
            var data = (from Cart in db.Carts
                        select new CartEntity()
                        {
                            CProductId = Cart.CProductId,
                            CProductName = Cart.CProductName,
                            CProductDescription = Cart.CProductDescription,
                            CProductPrice = (float)Cart.CProductPrice,
                            CProductImgId = Cart.CProductImgId
                        }).ToList();
            return data;
        }
        public bool InsertCProduct(CartEntity Cart)
        {
            if (db.Carts.Find(Cart.CProductId) == null)
            {
                Cart car = new Cart()
                {
                    CProductId = Cart.CProductId,
                    CProductName = Cart.CProductName,
                    CProductDescription = Cart.CProductDescription,
                    CProductPrice = Cart.CProductPrice,
                    CProductImgId = Cart.CProductImgId
                };
                try
                {
                    db.Carts.Add(car);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public bool UpdateCProduct(int CProductId, CartEntity Cart)
        {
            if (db.Carts.Find(Cart.CProductId) != null)
            {
                Cart car = new Cart()
                {
                    CProductId = Cart.CProductId,
                    CProductName = Cart.CProductName,
                    CProductDescription = Cart.CProductDescription,
                    CProductPrice = Cart.CProductPrice,
                    CProductImgId = Cart.CProductImgId
                };

                try
                {
                    Cart carData = db.Carts.Find(CProductId);
                    carData.CProductId = car.CProductId;
                    carData.CProductName = car.CProductName;
                    carData.CProductDescription = car.CProductDescription;
                    carData.CProductPrice = car.CProductPrice;
                    carData.CProductImgId = car.CProductImgId;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public bool DeleteCProduct(int CProductId)
        {
            try
            {
                Cart carData = db.Carts.Find(CProductId);

                if (carData != null)
                {
                    db.Carts.Remove(carData);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
    

