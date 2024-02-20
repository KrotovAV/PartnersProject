using BuissnesLayer;
using BuissnesLayer.Implementions;
using BuissnesLayer.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace TestAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IDirectrysRepository, EFDirectorysRepository>();
            builder.Services.AddTransient<IMaterialsRepository, EFMaterialsRepository>();
            builder.Services.AddScoped<DataManager>();


            builder.Services.AddSingleton<EFDBContext>();

            //builder.Services.AddSingleton<IProductService, ProductService>();
            //builder.Services.AddSingleton<IGroupService, GroupService>();
            //builder.Services.AddSingleton<IStoreService, StoreService>();
          



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //---------------------
            builder.Configuration.GetConnectionString("Connection");

            var confBuilder = new ConfigurationBuilder();
            confBuilder.SetBasePath(Directory.GetCurrentDirectory());
            confBuilder.AddJsonFile("appsettings.json");
            var cfg = confBuilder.Build();
            //-----------------
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            
            using (var context = new EFDBContext())
            {
                SimplData.InitData(context);
              
            }
            
            app.Run();
        }
    }
}