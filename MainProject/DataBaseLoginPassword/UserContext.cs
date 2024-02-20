using DataBaseLoginPassword.DB;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataBaseLoginPassword
{
    public class UserContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
        
        //dotnet ef migrations add InitialMigration
        //dotnet ef database update

        public UserContext()
        {

        }
        public UserContext(DbContextOptions dbc) : base(dbc)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();

            optionsBuilder.UseLazyLoadingProxies().
                    UseSqlServer(config.GetConnectionString("Connection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pkey");
                //entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => new { e.Name, e.RoleId }).IsUnique();
                // уникальность одновременно по имени и по роли, т.е. на одной эл почте м.б. две роли

                entity.ToTable("Users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Salt).HasColumnName("salt");

                entity.Property(e => e.RoleId).HasConversion<int>();
            });

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleId)
                .HasConversion<int>();

            modelBuilder.Entity<Role>()
                .HasData(Enum.GetValues(typeof(RoleId))
                .Cast<RoleId>()
                .Select(e => new Role()
                {
                    RoleId = e,
                    Name = e.ToString()
                }
                ));
            //---------
            /*чтобы сохранить пароль, мы:
                ● Получаем из нашей строки-пароля массив байт,
                ● Получаем случайный массив байт и сохраняем его в поле Salt,
                ● Конкатенируем байты, полученные из пароля, с байтами Salt,
                ● Получаем Hash-сумму от полученного массива и сохраняем в поле Password

            Чтобы проверить пароль:
                ● Получаем из нашей строки-пароля массив байт,
                ● Конкатенируем байты, полученные из пароля, с байтами Salt,
                ● Получаем Hash-сумму и сравниваем с сохраненной в поле Password.
            */
            //---------
            var admin = new User();
            admin.Id = Guid.NewGuid();
            admin.Name = "KrotovAV@tut.by";
            string password = "Admin";
            admin.RoleId = 0;
            admin.Salt = new byte[16];
            new Random().NextBytes(admin.Salt);
            var data = Encoding.ASCII.GetBytes(password).Concat(admin.Salt).ToArray();
            SHA512 shaM = new SHA512Managed();
            admin.Password = shaM.ComputeHash(data);

            modelBuilder.Entity<User>().HasData(admin);

            byte[] salt2 = new byte[16];
            new Random().NextBytes(salt2);
            byte[] salt3 = new byte[16];
            new Random().NextBytes(salt3);

            modelBuilder.Entity<User>().HasData(
            new User {
                Id = Guid.NewGuid(), 
                Name = "KrotovAV@tut.by",
                Salt = salt2,
                Password = new SHA512Managed().ComputeHash(Encoding.ASCII.GetBytes("Founder").Concat(salt2).ToArray()),
                RoleId = RoleId.Founder
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "KrotovAV@tut.by",
                Salt = salt3,
                Password = new SHA512Managed().ComputeHash(Encoding.ASCII.GetBytes("Follower").Concat(salt3).ToArray()),
                RoleId = RoleId.Follower}
            );
            //------------------
        }
    }
}
