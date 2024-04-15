using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SliderService:ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderService(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void AddAsync(Slider entity)
        {
            _sliderDal.Add(entity);
        }

        public void DeleteAsync(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public Slider GetByIdAsync(int id)
        {
           return _sliderDal.GetById(id);
        }

        public List<Slider> GetListAllAsync()
        {
            return _sliderDal.GetListAll();
        }

        public void UpdateAsync(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
