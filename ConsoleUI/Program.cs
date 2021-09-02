using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Name = " + item.CarName + " Color = " + item.ColorName 
                    + " Brand = " + item.BrandName + " Model = " + item.ModelYear
                    + " Daily Price = " + item.DailyPrice + " Description = " + item.Description);
            }


        }
    }
}
