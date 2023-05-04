

using Buisness.Concrete;
using DataAccess.Concrete.EntityFramework;

CarManager carManager = new CarManager(new EFCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description); 
   
}
