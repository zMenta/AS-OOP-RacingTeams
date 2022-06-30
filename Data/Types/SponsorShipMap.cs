using AS_OOP_RacingTeams.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AS_OOP_RacingTeams.Data.Types
{
    public class SponsorShipMap : IEntityTypeConfiguration<SponsorShip>
    {
        public void Configure(EntityTypeBuilder<SponsorShip> builder)
        {
            builder.ToTable("sponsorShips");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}