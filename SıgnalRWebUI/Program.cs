using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Net;

namespace SıgnalRWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Authentication İşlemleri için eklendi.
            var requiredAuthorizePoliciy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //Authentice olmuş kullanıyı zorunlu kıl.(İlk Adım)

            // Add services to the container.
            builder.Services.AddDbContext<SignalRContext>();
            builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<SignalRContext>();  //Identity için ekledik

            //Bütün controller ların içinde Authorization işlemlerini uygula anlamına geliyor.
            //Bu şekilde proje seviyesinde Authenticate işlemini gerçekleştirmiş olduk.
            builder.Services.AddControllersWithViews(opt =>
            {
                opt.Filters.Add(new AuthorizeFilter(requiredAuthorizePoliciy)); //Authentication işlemleri için ikinci adım olarak zaten controller olarak eklediğimiz AddControllersWithViews metoduna opt ile ekledik
            });

            //Otomatik olarak Account/Login diye bir sayfaya yönlendiryordu proje çalıştığında onu engellemek için Login/Index e atsın istediğim için bunu yazdım.
            builder.Services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = "/Login/Index";
            });

            

            builder.Services.AddHttpClient();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}