using ShoppingBussinessLayer;
using ShoppingEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingDetails.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/Product/{ProductId}")]
        public HttpResponseMessage GetProductDetailsById(int ProductId)
        {
            ProductBussinessLayer productBussiness = new ProductBussinessLayer();
            var data = productBussiness.GetProductDetailById(ProductId);
            if (!data.Any())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Product Not Found.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
        }
        [HttpGet]
        [Route("api/Product")]
        public List<ProductEntity> GetProductDetail()
        {
            ProductBussinessLayer productBussiness = new ProductBussinessLayer();
            return productBussiness.GetProductDetail();
        }

        [HttpPost]
        [Route("api/Product/insert")]
        public HttpResponseMessage InsertEmployee(ProductEntity Product)
        {
            ProductBussinessLayer productBussiness = new ProductBussinessLayer();
            if (productBussiness.InsertProduct(Product))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Inserted Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Product Already Exists!");
            }
        }
        [HttpPut]
        [Route("api/UpdateProduct/{ProductId}")]
        public HttpResponseMessage UpdateProduct(int ProductId, ProductEntity Product)
        {
            ProductBussinessLayer productBussiness = new ProductBussinessLayer();
            if (productBussiness.UpdateProduct(ProductId, Product))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Updated Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Product does not exist.!");
            }
        }
        [HttpDelete]
        [Route("api/Product/{ProductId}")]
        public HttpResponseMessage DeleteEmployee(int ProductId)
        {
            ProductBussinessLayer productBussiness = new ProductBussinessLayer();
            if (productBussiness.DeleteProduct(ProductId))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Product Deleted Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Product does not exists.!");
            }
        }

    }
}
