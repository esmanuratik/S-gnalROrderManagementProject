﻿using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDiscountDal:IGenericDal<Discount>
    {
        void ChangeStatusToTrue(int id);
        void ChangeStatusToFalse(int id);
        /// <summary>
        /// Durumu True Olanlara Göre Getiren Metot
        /// </summary>
        /// <returns></returns>
        List<Discount> GetListByStatusTrue();    
    }
}
