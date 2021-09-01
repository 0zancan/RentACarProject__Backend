using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id= 1, BrandId=1, ColorId=1, DailyPrice = 100000, Description="hyundai", ModelYear = 2010 },
                new Car{ Id= 2, BrandId=2, ColorId=2, DailyPrice = 200000, Description="kia", ModelYear = 2012 },
                new Car{ Id= 3, BrandId=3, ColorId=3, DailyPrice = 400000, Description="renault", ModelYear = 2019 },
                new Car{ Id= 4, BrandId=4, ColorId=4, DailyPrice = 300000, Description="volvo", ModelYear = 2021 }
            };
        }

        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(x => x.BrandId == brandId).ToList();
        }

        public List<Car> GetAllCars()
        {
            return _cars;
        }

        public Car GetCarById(int id)
        {
            return _cars.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
