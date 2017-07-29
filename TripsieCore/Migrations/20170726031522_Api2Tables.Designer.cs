using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TripsieCore.Models;

namespace TripsieCore.Migrations
{
    [DbContext(typeof(TripsieContext))]
    [Migration("20170726031522_Api2Tables")]
    partial class Api2Tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("TripComment");
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

                    b.ToTable("TripUser");
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
