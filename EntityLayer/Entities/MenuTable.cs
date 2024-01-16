﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	/// <summary>
	/// Masa Sayısını burada tutacağız
	/// </summary>
	public class MenuTable
	{
		public int MenuTableID { get; set; }	
		public string Name { get; set; }
		public bool Status { get; set; }

        //İlişkili Tablolar

        public List<Basket> Baskets { get; set; }
    }
}
