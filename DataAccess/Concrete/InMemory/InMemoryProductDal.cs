using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {ID=1, BrandId=1, ColorId=1, DailyPrice=25, ModelYear="1999",Description="Supersport"},
                new Product {ID=1, BrandId=2, ColorId=1, DailyPrice=40, ModelYear="1998",Description="Classic"},
                new Product {ID=2, BrandId=2, ColorId=2, DailyPrice=50, ModelYear="1997",Description="PickUp"},
                new Product {ID=2, BrandId=2, ColorId=2, DailyPrice=60, ModelYear="1996",Description="TWheel"},
                new Product {ID=2, BrandId=2, ColorId=2, DailyPrice=61, ModelYear="1995",Description="Truck"},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ID == product.ID);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ID == product.ID);
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.ColorId = product.ColorId;
            productToUpdate.DailyPrice = product.DailyPrice;
            productToUpdate.Description = product.Description;
            productToUpdate.ModelYear = product.ModelYear;
        }
    }
}
