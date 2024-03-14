using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class AppUser:IdentityUser<int>//ID yi normalde string olarak alıyor ama ben int olarak kullandığım için şu anda da böyle alsın istiyorum.
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
