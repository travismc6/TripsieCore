using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TripsieCore.Models;

namespace TripsieCore.Migrations
{
    [DbContext(typeof(TripsieContext))]
    partial class TripsieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TripsieCore.Models.ActivityVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TripActivityId");

                    b.Property<int>("TripUserId");

                    b.Property<int>("Vote");

                    b.HasKey("Id");

                    b.HasIndex("TripActivityId");

                    b.HasIndex("TripUserId");

                    b.ToTable("ActivityVotes");
                });

            modelBuilder.Entity("TripsieCore.Models.PushRegistrations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RegistrationId");

                    b.Property<int>("TripUserId");

                    b.HasKey("Id");

                    b.HasIndex("TripUserId");

                    b.ToTable("PushRegistrations");
                });

            modelBuilder.Entity("TripsieCore.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<string>("Destination")
                        .IsRequired();

                    b.Property<string>("EndDate");

                    b.Property<string>("MyName")
                        .IsRequired();

                    b.Property<string>("StartDate");

                    b.Property<int>("Status");

                    b.Property<string>("UserJson");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TripsieCore.Models.TripActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activity");

                    b.Property<string>("Details");

                    b.Property<bool>("IsComplete");

                    b.Property<long>("Lat");

                    b.Property<long>("Lon");

                    b.Property<int>("TripId");

                    b.Property<int>("TripUserId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripActivities");
                });

            modelBuilder.Entity("TripsieCore.Models.TripComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("DetailId");

                    b.Property<int>("TripUserId");

                    b.HasKey("Id");

                    b.HasIndex("TripUserId");

                    b.ToTable("TripComments");
                });

            modelBuilder.Entity("TripsieCore.Models.TripUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email");

                    b.Property<bool>("IsCreator");

                    b.Property<long>("Lat");

                    b.Property<long>("Lon");

                    b.Property<string>("Phone");

                    b.Property<string>("TripCode");

                    b.Property<int?>("TripId");

                    b.Property<int>("TripStatus");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripUsers");
                });

            modelBuilder.Entity("TripsieCore.Models.ActivityVote", b =>
                {
                    b.HasOne("TripsieCore.Models.TripActivity", "TripActivity")
                        .WithMany("ActivityVotes")
                        .HasForeignKey("TripActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TripsieCore.Models.TripUser", "TripUser")
                        .WithMany()
                        .HasForeignKey("TripUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripsieCore.Models.PushRegistrations", b =>
                {
                    b.HasOne("TripsieCore.Models.TripUser", "TripUser")
                        .WithMany()
                        .HasForeignKey("TripUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripsieCore.Models.TripActivity", b =>
                {
                    b.HasOne("TripsieCore.Models.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripsieCore.Models.TripComment", b =>
                {
                    b.HasOne("TripsieCore.Models.TripUser", "TripUser")
                        .WithMany("TripComments")
                        .HasForeignKey("TripUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripsieCore.Models.TripUser", b =>
                {
                    b.HasOne("TripsieCore.Models.Trip", "Trip")
                        .WithMany("Users")
                        .HasForeignKey("TripId");
                });
        }
    }
}
