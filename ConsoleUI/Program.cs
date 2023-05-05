

using Buisness.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

//CarManager carManager = new CarManager(new EFCarDal());
//foreach (var car in carManager.GetAll())
//{
//    Console.WriteLine(car.Description); 

//}

//CarManager carManager = new CarManager(new EFCarDal());
//foreach (var car in carManager.GetCarsByBrandId(3))
//{
//    Console.WriteLine(car.ModelYear);
//}

CarManager carManager = new CarManager(new EFCarDal());
carManager.Add(new Car()
{
    BrandId = 1,
    ColorId = 1,
    DailyPrice = 250, // 0 veya eksi girersek consola hata fırlatma işlemi yaptık
    Description = "Bu bir BMW serisinden araçtır",
    ModelYear = 2018
});

Console.WriteLine(carManager.GetByCarId(4).ModelYear);