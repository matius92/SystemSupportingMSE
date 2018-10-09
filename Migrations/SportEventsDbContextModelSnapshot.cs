﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SystemSupportingMSE.Helpers;

namespace SystemSupportingMSE.Migrations
{
    [DbContext(typeof(SportEventsDbContext))]
    partial class SportEventsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.Events.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("GroupSize");

                    b.Property<bool>("GroupsRequired");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("EventEnds");

                    b.Property<DateTime>("EventStarts");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.Events.EventCompetition", b =>
                {
                    b.Property<int>("CompetitionId");

                    b.Property<int>("EventId");

                    b.Property<DateTime>("CompetitionDate");

                    b.Property<TimeSpan?>("TimePerGroup");

                    b.HasKey("CompetitionId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventsCompetitions");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.Events.UserCompetition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompetitionId");

                    b.Property<int>("EventId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("CompetitionId", "EventId");

                    b.ToTable("UsersCompetitions");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.Gender", b =>
                {
                    b.Property<byte>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Captain");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateOfRegistration");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<byte>("GenderId");

                    b.Property<DateTime?>("LastLogin");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.UserTeam", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("TeamId");

                    b.Property<bool>("Status");

                    b.HasKey("UserId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("UserTeams");
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.Events.EventCompetition", b =>
                {
                    b.HasOne("SystemSupportingMSE.Core.Models.Events.Competition", "Competition")
                        .WithMany("Events")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SystemSupportingMSE.Core.Models.Events.Event", "Event")
                        .WithMany("Competitions")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.Events.UserCompetition", b =>
                {
                    b.HasOne("SystemSupportingMSE.Core.Models.User", "User")
                        .WithMany("Competitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SystemSupportingMSE.Core.Models.Events.EventCompetition", "EventCompetition")
                        .WithMany("UsersCompetitions")
                        .HasForeignKey("CompetitionId", "EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.User", b =>
                {
                    b.HasOne("SystemSupportingMSE.Core.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.UserRole", b =>
                {
                    b.HasOne("SystemSupportingMSE.Core.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SystemSupportingMSE.Core.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SystemSupportingMSE.Core.Models.UserTeam", b =>
                {
                    b.HasOne("SystemSupportingMSE.Core.Models.Team", "Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SystemSupportingMSE.Core.Models.User", "User")
                        .WithMany("Teams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
