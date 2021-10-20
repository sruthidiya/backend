using ShoppingEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataLayer
{
   public class ProductDataAccessLayer
    {
        trainingDBEntities db = new trainingDBEntities();
        public List<ProductEntity> GetProductDetailsById(int ProductId)
        {
        var data = (from Product in db.Protables
                    where Product.ProductId == ProductId
                    select new ProductEntity()
                    {
                        ProductId = Product.ProductId,
                        ProductName = Product.ProductName,
                        ProductDescription = Product.ProductDescription,
                        ProductPrice = (float)Product.ProductPrice,
                        ProductImgId = Product.ProductImgId
                    }).ToList();
        return data;
    }
    public List<ProductEntity> GetProductDetails()
    {
        var data = (from Product in db.Protables
                    select new ProductEntity()
                    {
                        ProductId = Product.ProductId,
                        ProductName = Product.ProductName,
                        ProductDescription = Product.ProductDescription,
                        ProductPrice = (float)Product.ProductPrice,
                        ProductImgId = Product.ProductImgId
                    }).ToList();
        return data;
    }
    public bool InsertProduct(ProductEntity Product)
    {
        if (db.Protables.Find(Product.ProductId) == null)
        {
                Protable pro = new Protable()
            {
                ProductId = Product.ProductId,
                ProductName = Product.ProductName,
                ProductDescription = Product.ProductDescription,
                ProductPrice = Product.ProductPrice,
                ProductImgId = Product.ProductImgId
            };
            try
            {
                db.Protables.Add(pro);
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
    public bool UpdateProduct(int ProductId, ProductEntity Product)
    {
        if (db.Protables.Find(Product.ProductId) != null)
        {
                Protable pro = new Protable()
            {
                ProductId = Product.ProductId,
                ProductName = Product.ProductName,
                ProductDescription = Product.ProductDescription,
                ProductPrice = Product.ProductPrice,
                ProductImgId = Product.ProductImgId
            };

            try
            {
                Protable proData = db.Protables.Find(ProductId);
                proData.ProductId = pro.ProductId;
                proData.ProductName = pro.ProductName;
                proData.ProductDescription = pro.ProductDescription;
                proData.ProductPrice = pro.ProductPrice;
                proData.ProductImgId = pro.ProductImgId;
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
    public bool DeleteProduct(int ProductId)
    {
        try
        {
                Protable proData = db.Protables.Find(ProductId);

            if (proData != null)
            {
                db.Protables.Remove(proData);
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