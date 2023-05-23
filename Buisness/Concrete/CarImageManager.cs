using Buisness.Abstract;
using Buisness.Constants;
using Core.Ultities.Buisness;
using Core.Ultities.Helpers.FileHelper;
using Core.Ultities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper ;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BuisnessRules.Run(CheckCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.ImageDate = DateTime.UtcNow;
            _carImageDal.Add(carImage);
            return new SuccessResult("resim başarıyla eklendi");
        }

        public IResult Delete(CarImage carImage)
        {

            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath); // İmagePath Benim dosyamı belirttiğim yol yani wwwroot içinde
            _carImageDal.Delete(carImage);
            return new SuccessResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BuisnessRules.Run(CheckCarImage(carId));
            if (result!=null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));

        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(c => c.CarImageId == imageId));
        }

        public IResult Update(IFormFile file, CarImage carImage) // file dediğim şşeye postmande image dedim yükleyeceğim resim o
        {
            carImage.ImagePath = _fileHelper.Update(file,PathConstants.ImagesPath+carImage.ImagePath,PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult("Güncellendi. ");
        }

        private IResult CheckCarImageLimit(int id)
        {
            var result = _carImageDal.GetAll().Count;
            if (result>5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckCarImage(int id)
        {
            var result = _carImageDal.GetAll(x=>x.CarId==id).Count;
            if (result > 0)
            {
                return new SuccessResult();

            }
            return new ErrorResult();

        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, ImageDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
    }
}
