using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                var result = from c in reCapProjectContext.Cars
                             join co in reCapProjectContext.Colors
                             on c.ColorId equals co.Id
                             join b in reCapProjectContext.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto { CarId = c.Id, ColorName = co.Name, BrandName = b.Name, DailyPrice = c.DailyPrice };

                return result.ToList();
            }
        }
    }
}
