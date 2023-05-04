using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        Car GetByCarId(int carId);
        List<Car> GetAll();
    }
}
