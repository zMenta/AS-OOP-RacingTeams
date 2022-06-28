using AS_OOP_RacingTeams.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AS_OOP_RacingTeams.Data.Types
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("persons");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(i => i.Birth_year)
                .HasColumnName("birth_year")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(i => i.JobId)
                .HasColumnName("job_id")
                .HasColumnType("integer")
                .IsRequired();

        }
    }
}