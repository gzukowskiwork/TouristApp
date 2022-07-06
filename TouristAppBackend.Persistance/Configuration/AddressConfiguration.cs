using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Persistance.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
