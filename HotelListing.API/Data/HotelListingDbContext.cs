using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country(){
                    Id = 1,
                    Name = "Jamaica",
                    ShortName = "JM"
                },
                new Country(){
                    Id = 2,
                    Name = "Brasil",
                    ShortName = "BR"
                },
                new Country(){
                    Id = 3,
                    Name = "Estados Unidos",
                    ShortName = "US"
                }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel(){
                    Id = 1,
                    Name ="Sandals Resort and Spa",
                    Address = "Negril",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel(){
                    Id = 2,
                    Name ="Guaruja Hotel",
                    Address = "Guarujá Cidade",
                    CountryId = 2,
                    Rating = 3.5
                },
                new Hotel(){
                    Id = 3,
                    Name ="Tower Power",
                    Address = "New York",
                    CountryId = 3,
                    Rating = 5
                }
            );
        }
    }
}