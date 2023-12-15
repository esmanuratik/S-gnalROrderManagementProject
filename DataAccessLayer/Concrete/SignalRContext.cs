using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class SignalRContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ESMANUR\\SQLEXPRESS;Initial Catalog=SignalRDb;Integrated Security=True;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> ?Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature>  Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
