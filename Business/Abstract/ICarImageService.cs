using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IResult AddCarImage(IFormFile formFile, CarImage carImage);
        IResult DeleteCarImage(IFormFile formFile, CarImage carImage);
        IResult UpdateCarImage(IFormFile formFile, CarImage carImage);
    }
}

