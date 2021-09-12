using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;


namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IResult AddCarImage(CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
        IResult UpdateCarImage(CarImage carImage);
    }
}

