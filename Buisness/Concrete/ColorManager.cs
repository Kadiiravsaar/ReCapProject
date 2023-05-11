using Buisness.Abstract;
using Core.Ultities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Buisness.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult("Ürün eklendi.");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult("Ürün Silindi.");

        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), "ürünler listelendi");
        }

        public IDataResult<Color> GetByColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.GetById(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult("Ürün güncellendi.");

        }
    }
}
