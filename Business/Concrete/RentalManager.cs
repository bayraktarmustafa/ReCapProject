using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        

        public RentalManager(IRentalDal rentalDal)
        {

            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if(rental.ReturnDate==null)
            {
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarNotAdded);
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}

