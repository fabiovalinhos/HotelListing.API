using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Country>(entity =>
               {
                   // Configuração da chave primária
                   entity.HasKey(e => e.Id);

                   // Configuração da propriedade Name como obrigatória
                   entity.Property(e => e.Name).IsRequired();

                   // Configurações adicionais, se necessário
                   // ...

                   // Configuração da relação com Hotel
                   entity.HasMany(c => c.Hotels)
                         .WithOne(h => h.Country)
                         .HasForeignKey(h => h.CountryId)
                         .OnDelete(DeleteBehavior.Cascade); // Defina o comportamento de exclusão adequado aqui, se necessário
               });

            modelBuilder.Entity<Hotel>(entity =>
            {
                // Configuração da chave primária
                entity.HasKey(e => e.Id);

                // Configuração da propriedade Name como obrigatória
                entity.Property(e => e.Name).IsRequired();

                // Configurações adicionais, se necessário
                // ...

                // Configuração da relação com Country (opcional)
                // Nesse caso, a configuração da relação já foi definida no modelo Country
                // No entanto, você pode adicionar configurações adicionais aqui, se necessário
            });


            modelBuilder.Entity<Country>().HasData(
                new Country()
                {
                    Id = 1,
                    Name = "Jamaica",
                    ShortName = "JM"
                },
                new Country()
                {
                    Id = 2,
                    Name = "Brasil",
                    ShortName = "BR"
                },
                new Country()
                {
                    Id = 3,
                    Name = "Estados Unidos",
                    ShortName = "US"
                }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    Id = 1,
                    Name = "Sandals Resort and Spa",
                    Address = "Negril",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel()
                {
                    Id = 2,
                    Name = "Guaruja Hotel",
                    Address = "Guarujá Cidade",
                    CountryId = 2,
                    Rating = 3.5
                },
                new Hotel()
                {
                    Id = 3,
                    Name = "Tower Power",
                    Address = "New York",
                    CountryId = 3,
                    Rating = 5
                }
            );
        }
    }
}