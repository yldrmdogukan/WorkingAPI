using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proggramming.DAL
{
    public class ProductDal
    {
        NorthwindEntities northwindEntities = new NorthwindEntities();

        public IEnumerable<Products> GetAllProducts()
        {
            return northwindEntities.Products;
        }

        public Products GetProductsId(int id)
        {
            return northwindEntities.Products.Find(id);
        }

        public Products CreateProduct(Products products)
        {
            northwindEntities.Products.Add(products);
            northwindEntities.SaveChanges();
            return products; //? 
        }
        public Products UpdateProducts(int id, Products products)
        {
            northwindEntities.Entry(products).State = System.Data.Entity.EntityState.Modified;
            northwindEntities.SaveChanges();
            return products;
        }
        public void DeleteProduct(int id)
        {
            northwindEntities.Products.Remove(northwindEntities.Products.Find(id));
            northwindEntities.SaveChanges();
        }  
        public bool IsThereAnyLanguage(int id)
        {
            return northwindEntities.Products.Any(x => x.ProductID==id);
        }

    }
}
