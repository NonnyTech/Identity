using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nonny.Model;

namespace Nonny.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//to override default functions of category
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 } //on category we want to create this three record on data base

                );

            modelBuilder.Entity<Product>().HasData(

                new Product { Id=1, Title="fortune of time", Author="Stanley", ISBN="23456666", ListPrice=100, Price=90, Price50=80, Price100=85},
                new Product { Id = 2, Title = "fortune of love", Author = "Nonny", ISBN = "23456667", ListPrice = 500, Price = 490, Price50 = 480, Price100 = 450 },
                new Product { Id = 3, Title = "fortune of hatred", Author = "Rachael", ISBN = "23456661", ListPrice = 1000, Price = 1900, Price50 = 1800, Price100 = 1750 },
                new Product { Id = 4, Title = "fortune of money", Author = "Ikemefuna", ISBN = "33456666", ListPrice = 200, Price = 190, Price50 = 180, Price100 = 170 }
                


                );


        }

    }
}