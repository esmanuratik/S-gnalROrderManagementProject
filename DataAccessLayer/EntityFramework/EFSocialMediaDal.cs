using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFSocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        public EFSocialMediaDal(SignalRContext context) : base(context)
        {
        }
    }
}
