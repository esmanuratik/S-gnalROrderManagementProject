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
	public class MessageService : IMessageService
	{
		private readonly IMessageDal _messageDal;

		public MessageService(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void AddAsync(Message entity)
		{
			_messageDal.Add(entity);
		}

		public void DeleteAsync(Message entity)
		{
			_messageDal.Delete(entity);
		}

		public Message GetByIdAsync(int id)
		{
			return _messageDal.GetById(id);
		}

		public List<Message> GetListAllAsync()
		{
			return _messageDal.GetListAll();
		}

		public void UpdateAsync(Message entity)
		{
			_messageDal.Update(entity);
		}
	}
}
