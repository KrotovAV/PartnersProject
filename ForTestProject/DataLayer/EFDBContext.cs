using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data;


namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Directry> Directry { get; set; }
        public DbSet<Material> Material { get; set; }

        public EFDBContext()
        {
        }
        public EFDBContext(DbContextOptions dbc) : base(dbc)
        {
        }

        //dotnet ef migrations add InitialMigration
        //dotnet ef database update

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


            // int Id, string Title, string Html, virtual List<Material> Materials
            modelBuilder.Entity<Directry>(entity =>
            {
                entity.ToTable("Directry");     //OK

                entity.HasKey(e => e.Id).HasName("directry_primary_key");   //OK
                entity.HasIndex(e => e.Id).IsUnique();  //OK

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("Title");

                entity.Property(e => e.Html).HasColumnName("Html");

            });

            modelBuilder.Entity<Directry>().HasData(
                new Directry() { Id = 1, Title = "First Directory", Html = "<b>Directory Content</b>" },
                new Directry() { Id = 2, Title = "Second Directory", Html = "<b>Directory Content</b>" }
            );


            // int Id, string Title, string Html, int DirectoryId - внешний ключ, virtual Directry Directory - навигацинное свойство
            modelBuilder.Entity<Material>(entity =>
                {
                    entity.ToTable("Material");     //OK

                    entity.HasKey(e => e.Id).HasName("material_primary_key");   //OK
                    entity.HasIndex(e => e.Id).IsUnique();  //OK

                    entity.HasOne(u => u.Directry)
                        .WithMany(c => c.Materials)
                        .HasForeignKey(u => u.DirectryId);

                    entity.Property(e => e.Id).HasColumnName("id");
                    entity.Property(e => e.Title)
                        .HasMaxLength(255)
                        .HasColumnName("Title");
                    entity.Property(e => e.Html).HasColumnName("Html");

                });

            modelBuilder.Entity<Material>().HasData(
                new Material() { Id = 1, Title = "First Material", Html = "<i>Material Content</i>", DirectryId = 1 },
                new Material() { Id = 2, Title = "Second Material", Html = "<i>Material Content</i>", DirectryId = 2 },
                new Material() { Id = 3, Title = "Third Material", Html = "<i>Material Content</i>", DirectryId = 2 }
            );
        }
    }
}