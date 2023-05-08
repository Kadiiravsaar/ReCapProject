using Core.DataAccess.EntityFramework;
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
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto{
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
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
