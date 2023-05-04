using Buisness.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class CarManager : IService<Car>
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car entity)
        {
            _carDal.Add(entity);
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> GetAll()
        {
           return _carDal.GetAll();
        }

        public Car GetByCarId(int id)
        {
            return _carDal.GetById(c => c.Id == id);
        }

        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
