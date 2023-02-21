using Elfo_Learning.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elfo_Learning.Context
{
    public class ElfoContext:DbContext
    {
        public ElfoContext(DbContextOptions<ElfoContext> options):base(options)
        {
            Database.Migrate();
        }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id=1,
                    Country = "Azerbaijan",
                    Name = "Baku"
                },
                new City
                {
                    Id = 2,
                    Country = "Italy",
                    Name = "Milan"
                },
                new City
                {

                    Id = 3,
                    Country = "Turkey",
                    Name = "Istanbul"
                },
                new City
                {

                    Id = 4,
                    Country = "Ukraine",
                    Name = "Kiev"
                },
                new City
                {

                    Id = 5,
                    Country = "Georgia",
                    Name = "Batumi"
                }
                );
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
