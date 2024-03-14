using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class AppRole:IdentityRole<int>//AppRole oluşturmamın tek sebebi context de yazdığımız Key olarak int vermemiz.
    {
    }
}
