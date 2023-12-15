using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Reflection;

namespace SıgnalRApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SignalRContext>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//Mapleme işlemi yaptığımı ve bunu burada belli ediyorum.

            builder.Services.AddScoped<IAboutService, AboutService>();
            builder.Services.AddScoped<IAboutDal,EFAboutDal>();

            builder.Services.AddScoped<IBookingService,BookingService>();   
            builder.Services.AddScoped<IBookingDal,EFBookingDal>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();

            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IContactDal, EFContactDal>();

            builder.Services.AddScoped<IDiscountService, DiscountService>();
            builder.Services.AddScoped<IDiscountDal, EFDiscountDal>();

            builder.Services.AddScoped<IFeatureService, FeatureService>();
            builder.Services.AddScoped<IFeatureDal, EFFeatureDal>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductDal, EFProductDal>();

            builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
            builder.Services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();

            builder.Services.AddScoped<ITestimonialService, TestimonialService>();
            builder.Services.AddScoped<ITestimonialDal, EFTestimonialDal>();



            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}