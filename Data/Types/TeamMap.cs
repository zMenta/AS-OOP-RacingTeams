using AS_OOP_RacingTeams.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AS_OOP_RacingTeams.Data.Types
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("teams");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(i => i.Cnpj)
                .HasColumnName("cnpj")
                .HasColumnType("integer")
                .HasMaxLength(14)
                .IsRequired();

            // builder.HasMany(i => i.Persons)
            //     .WithMany(i => i.Teams)
            //     .UsingEntity<>;

            builder.HasMany(i => i.SponsorShips)
                .WithMany(i => i.Teams);
                // .UsingEntity<Dictionary<string, object>>(
                //     "team_sponsor",
                //     team => team
                //         .HasOne<Team>()
                //         .WithMany()
                //         .HasForeignKey("team_id")
                //         .HasConstraintName("FK_team_sponsor_team_id")
                //         .OnDelete(DeleteBehavior.Cascade),
                //     sponsor => sponsor
                //             .HasOne<SponsorShip>()
                //             .WithMany()
                //             .HasForeignKey("sponsor_id")
                //             .HasConstraintName("FK_team_sponsor_sponsor_id")
                //             .OnDelete(DeleteBehavior.Cascade));

        }
    }
}