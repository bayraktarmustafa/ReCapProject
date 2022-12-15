using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        {
            if (product.DailyPrice == 0)
            {
                return new ErrorResult(Messages.CarPriceFault);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.CarAdded);
        }
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.CarsListed);
        }
        public IDataResult<List<Product>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Product>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.BrandId == id));
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.CarUpdated);
        }

      public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

    }
}
