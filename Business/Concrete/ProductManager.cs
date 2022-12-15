using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            return _productDal.GetAll();

        }
       
        public void Add(Product product)
        {
            if(product.Description.Length>2 && product.DailyPrice>0)
            {
                _productDal.Add(product);
            }
            else
            {
                Console.WriteLine("Girilen Bilgileri Kontrol Ediniz");
            }
        }

        public List<Product>GetCarsByBrandId(int id)
        {
            return _productDal.GetAll(p => p.BrandId == id);
        }
        public List<Product> GetCarsByColorId(int id)
        {
            return _productDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Product product)
        {
           
        }

     

        public void Delete(Product product)
        {

            _productDal.Delete(product);
        }

      

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
