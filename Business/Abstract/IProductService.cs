using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetCarsByBrandId(int id);
        IDataResult<List<Product>> GetCarsByColorId(int id);
        IResult Add(Product product);
        IResult Delete(Product product);
       IResult Update(Product product);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
    }
}
