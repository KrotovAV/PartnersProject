using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using WebApplication03HW2.Models;

namespace WebApplication03HW2.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }

        public DBContext()
        {

        }
        public DBContext(DbContextOptions dbc) : base(dbc)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //                .AddJsonFile("appsettings.json")
        //                .SetBasePath(Directory.GetCurrentDirectory())
        //                .Build();


        //    optionsBuilder.UseMySql(config.GetConnectionString("Connection"),
        //        new MySqlServerVersion(new Version(8, 0, 11)));
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();

            optionsBuilder.UseLazyLoadingProxies().
                UseNpgsql(config.GetConnectionString("Connection"));


        }
        //

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder
        //        .LogTo(Console.WriteLine)
        //        .UseNpgsql("host=127.0.0.1;port=5432;Database=DataBaseUsers;Username=postgres;password=PgSQLavk");

        //("Host=127.0.0.1;Port=5432;Database=DataBaseUsers;Username=postgres;Password=PgSQLavk");
        //"Host=localhost;Username=postgres;Password=example;Database=LibraryUsers" из лекции

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Store>(entity =>
            {

                entity.ToTable("Stores");

                entity.HasKey(x => x.Id)
                      .HasName("StoreID");
                entity.HasIndex(x => x.Name)
                      .IsUnique();

                entity.Property(e => e.Name)
                      .HasColumnName("StoreName");

                entity.Property(e => e.Description)
                      .HasColumnName("StoreDescription")
                      .HasMaxLength(255)
                      .IsRequired();

                //entity.Property(e => e.Count)
                //.HasColumnName("ProductCount");

                //entity.HasMany(x => x.Products)
                //.WithMany(m => m.Stores)
                //.UsingEntity(j => j.ToTable("StorageProduct"));
            });


        }
    }

}
