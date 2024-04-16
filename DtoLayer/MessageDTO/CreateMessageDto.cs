using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.MessageDTO
{
	public class CreateMessageDto
	{
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string PhoneNumber { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendDate { get; set; }
		/// <summary>
		/// Mesaj Bilgisi Okundu/Okunmadı
		/// </summary>
		public bool Status { get; set; }
	}
}
