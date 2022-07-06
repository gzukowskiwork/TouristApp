using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Persistance.Configuration
{
    public class PlaceConiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
