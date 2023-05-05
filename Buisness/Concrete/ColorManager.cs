using Buisness.Abstract;
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

        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(Color color)
        {
            _colorDal.Add(color);

        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetByColorId(int id)
        {
            return _colorDal.GetById(c => c.Id == id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);

        }
    }
}
