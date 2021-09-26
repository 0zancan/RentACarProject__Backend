using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using RentACarContext context = new RentACarContext();
            var result = from rental in context.Rentals
                         join car in context.Cars
                         on rental.CarId equals car.Id
                         join color in context.Colors
                         on car.ColorId equals color.Id
                         join brand in context.Brands
                         on car.BrandId equals brand.Id
                         join customer in context.Customers
                         on rental.CustomerId equals customer.Id
                         select new RentalDetailsDto
                             {
                                 Id = rental.Id,
                                 BrandName = brand.Name,
                                 CustomerName = customer.CompanyName,
                                 RentDate = rental.RentDate, 
                                 ReturnDate = rental.ReturnDate
                             };

            return result.ToList();
        }

        
    }
}
