using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T :class 
    {
        void AddAsync(T entity);
        void DeleteAsync(T entity);
        void UpdateAsync(T entity);
        T GetByIdAsync(int id);
        List<T> GetListAllAsync();
    }
}
