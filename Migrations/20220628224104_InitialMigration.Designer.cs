﻿// <auto-generated />
using AS_OOP_RacingTeams.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AS_OOP_RacingTeams.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220628224104_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AS_OOP_RacingTeams.Domain.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("jobs", (string)null);
                });

            modelBuilder.Entity("AS_OOP_RacingTeams.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Birth_year")
                        .HasColumnType("integer")
                        .HasColumnName("birth_year");

                    b.Property<int>("JobId")
                        .HasColumnType("integer")
                        .HasColumnName("job_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("persons", (string)null);
                });

            modelBuilder.Entity("AS_OOP_RacingTeams.Domain.Entities.SponsorShip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SponsorShip");
                });

            modelBuilder.Entity("AS_OOP_RacingTeams.Domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cnpj")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("PersonTeam", b =>
                {
                    b.Property<int>("PersonsId")
                        .HasColumnType("integer");

                    b.Property<int>("TeamsId")
                        .HasColumnType("integer");

                    b.HasKey("PersonsId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("PersonTeam");
                });

            modelBuilder.Entity("SponsorShipTeam", b =>
                {
                    b.Property<int>("SponsorShipsId")
                        .HasColumnType("integer");

                    b.Property<int>("TeamsId")
                        .HasColumnType("integer");

                    b.HasKey("SponsorShipsId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("SponsorShipTeam");
                });

            modelBuilder.Entity("AS_OOP_RacingTeams.Domain.Entities.Person", b =>
                {
                    b.HasOne("AS_OOP_RacingTeams.Domain.Entities.Job", "Job")
                        .WithMany("Person")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("PersonTeam", b =>
                {
                    b.HasOne("AS_OOP_RacingTeams.Domain.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AS_OOP_RacingTeams.Domain.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SponsorShipTeam", b =>
                {
                    b.HasOne("AS_OOP_RacingTeams.Domain.Entities.SponsorShip", null)
                        .WithMany()
                        .HasForeignKey("SponsorShipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AS_OOP_RacingTeams.Domain.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AS_OOP_RacingTeams.Domain.Entities.Job", b =>
                {
                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
