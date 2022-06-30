using AS_OOP_RacingTeams.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AS_OOP_RacingTeams.Data.Types
{
    public class SponsorShipMap : IEntityTypeConfiguration<SponsorShip>
    {
        public void Configure(EntityTypeBuilder<SponsorShip> builder)
        {
            builder.ToTable("SponsorShip");

            builder.Property(i => i.Id)
                .HasColumnName("Id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}