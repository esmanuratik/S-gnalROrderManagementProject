using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureService(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void AddAsync(Feature entity)
        {
            _featureDal.Add(entity);
        }

        public void DeleteAsync(Feature entity)
        {
            _featureDal.Delete(entity);
        }

        public Feature GetByIdAsync(int id)
        {
            return _featureDal.GetById(id);
        }

        public List<Feature> GetListAllAsync()
        {
           return _featureDal.GetListAll();
        }

        public void UpdateAsync(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
