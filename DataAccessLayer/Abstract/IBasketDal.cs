using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        //Masa numarasının id sine göre sepet
        List<Basket> GetBasketByMenuTableNumber(int id);
    }
}
