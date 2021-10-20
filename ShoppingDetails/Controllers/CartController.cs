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
    public class CartController : ApiController
    { 
     [HttpGet]
        [Route("api/Cart/{CProductId}")]
        public HttpResponseMessage GetCProductDetailsById(int CProductId)
    {
        CartBussinessLayer cartBussiness = new CartBussinessLayer();
        var data = cartBussiness.GetCProductDetailById(CProductId);
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
    [Route("api/Cart")]
    public List<CartEntity> GetCProductDetail()
    {
        CartBussinessLayer cartBussiness = new CartBussinessLayer();
        return cartBussiness.GetCProductDetail();
    }

    [HttpPost]
    [Route("api/Cart/insert")]
    public HttpResponseMessage InsertCProduct(CartEntity Cart)
    {
        CartBussinessLayer cartBussiness = new CartBussinessLayer();
        if (cartBussiness.InsertCProduct(Cart))
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Inserted Successfully.!");
        }
        else
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Product Already Exists!");
        }
    }
    [HttpPut]
    [Route("api/Cart/{CProductId}")]
    public HttpResponseMessage UpdateCProduct(int CProductId, CartEntity Cart)
    {
        CartBussinessLayer cartBussiness = new CartBussinessLayer();
        if (cartBussiness.UpdateCProduct(CProductId, Cart))
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Updated Successfully.!");
        }
        else
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Product does not exist.!");
        }
    }
    [HttpDelete]
    [Route("api/Cart/{CProductId}")]
    public HttpResponseMessage DeleteCProduct(int CProductId)
    {
        CartBussinessLayer cartBussiness = new CartBussinessLayer();
        if (cartBussiness.DeleteCProduct(CProductId))
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