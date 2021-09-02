using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager()
        {
        }

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarByBrandId(int brandId)
        {
            return _carDal.GetAll(x=>x.BrandId == brandId);
        }

        public List<Car> GetCarByColorId(int colorId)
        {
            return _carDal.GetAll(x => x.Id == colorId);
        }
    }
}
