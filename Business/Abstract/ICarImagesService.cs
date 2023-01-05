using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetById(int carId);
        IDataResult<CarImages> GetByImageId(int imageId);

        IResult Add(IFormFile file, CarImages carImage);
        IResult Delete(CarImages carImage);
        IResult Update(IFormFile file, CarImages carImage);

    }
}
