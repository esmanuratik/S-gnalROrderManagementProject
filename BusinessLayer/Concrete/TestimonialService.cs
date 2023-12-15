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
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialService(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void AddAsync(Testimonial entity)
        {
            _testimonialDal.Add(entity);
        }

        public void DeleteAsync(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
        }

        public Testimonial GetByIdAsync(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public List<Testimonial> GetListAllAsync()
        {
           return _testimonialDal.GetListAll();
        }

        public void UpdateAsync(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
