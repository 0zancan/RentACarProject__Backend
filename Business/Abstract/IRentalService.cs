using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAllRental();
        IDataResult<List<Rental>> GetCarByRentalId(int id);
        IDataResult<List<Rental>> GetCarByRentalCustomerId(int id);
        IResult AddRental(Rental rental);
        IResult DeleteRental(Rental rental);
        IResult UpdateRental(Rental rental);
    }
}
