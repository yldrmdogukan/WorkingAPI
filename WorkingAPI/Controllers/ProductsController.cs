using Proggramming.DAL;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI;
using WorkingAPI.Attributes;

namespace WorkingAPI.Controllers
{
    //[ApiExcepitonAttribute] //Uygulama seviyesine taşımak için.
    public class ProductsController : ApiController
    {
        ProductDal productDal = new ProductDal();

        [HttpGet]
        public IHttpActionResult GetSearchByName(string name)
        {
            return Ok("Name: " + name);
        }

        [ResponseType(typeof(IEnumerable<Products>))] //Dökümantasyon için
        [HttpGet] //Method ismi özelleştirmeye imkan sağlıyor.
        public IHttpActionResult Get()
        {
            dynamic a = 0;
            return 5 / a;
            var products = productDal.GetAllProducts();
            return Ok(products);
            //Request.CreateResponse(HttpStatusCode.OK, products);
        }
        public IHttpActionResult Get(int id)
        {
            var product = productDal.GetProductsId(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        public IHttpActionResult Post(Products products)
        {
            if (ModelState.IsValid)
            {
                var createdProduct = productDal.CreateProduct(products);
                return CreatedAtRoute("DefaultApi", new { id = createdProduct.ProductID }, createdProduct);
            }
            else
                return BadRequest(ModelState);
        }
        public IHttpActionResult Put(int id, Products products)
        {
            if (productDal.IsThereAnyLanguage(id) == false)
                return NotFound();
            else if (ModelState.IsValid == false)
                return BadRequest(ModelState);
            else
                return Ok(productDal.UpdateProducts(id, products));
        }
        public IHttpActionResult Delete(int id)
        {
            if (productDal.IsThereAnyLanguage(id) == false)
                return NotFound();
            else
            {
                productDal.DeleteProduct(id);
                return Ok();
            }

        }
    }
}
