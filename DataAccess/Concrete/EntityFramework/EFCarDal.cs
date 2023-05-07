﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepository<Car, AppDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto{
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice
                                 
                             };

                return result.ToList();
            }
           

        }
    }
}
