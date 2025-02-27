using Class_Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.InfraStructure.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f => f.Passengers)
                .WithMany(p => p.Flights)
                .UsingEntity(j => j.ToTable("FlightPassenger"));


            builder.HasOne(f => f.Plane)
                .WithMany(p => p.Flights)
                //.HasForeignKey(f => f.Planefk)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
