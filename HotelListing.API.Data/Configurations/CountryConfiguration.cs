using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}