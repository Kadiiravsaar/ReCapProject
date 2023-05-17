using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EFEntityRepository<Rental, AppDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             from u in context.Users
                             join cu in context.Customers
                             on u.UserId equals cu.UserId
                             select new RentalDetailDto()
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorName = co.Name,
                                 BrandName = b.Name,
                                 ModelName = c.CarName,
                                 RentalId = r.RentalId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CustomerName = u.FirstName,
                                 CustomerLastName = u.LastName

                             };
                return result.ToList();
            }
        }
    }
}
