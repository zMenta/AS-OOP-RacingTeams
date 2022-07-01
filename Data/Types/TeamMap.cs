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

            builder.HasMany(i => i.Persons)
                .WithMany(i => i.Teams)
                .UsingEntity<Dictionary<string, object>>(
                    "team_person",
                    person => person
                        .HasOne<Person>()
                        .WithMany()
                        .HasForeignKey("person_id")
                        .HasConstraintName("FK_team_person_person_id")
                        .OnDelete(DeleteBehavior.Cascade),
                    team => team
                        .HasOne<Team>()
                        .WithMany()
                        .HasForeignKey("team_id")
                        .HasConstraintName("FK_team_person_team_id")
                        .OnDelete(DeleteBehavior.Cascade));

            builder.HasMany(i => i.SponsorShips)
                .WithMany(i => i.Teams)
                .UsingEntity<Dictionary<string, object>>(
                    "team_sponsor",
                    sponsorShip => sponsorShip
                        .HasOne<SponsorShip>()
                        .WithMany()
                        .HasForeignKey("sponsor_id")
                        .HasConstraintName("FK_team_sponsor_sponsor_id")
                        .OnDelete(DeleteBehavior.Cascade),
                    team => team
                        .HasOne<Team>()
                        .WithMany()
                        .HasForeignKey("team_id")
                        .HasConstraintName("FK_team_sponsor_team_id")
                        .OnDelete(DeleteBehavior.Cascade));

        }
    }
}