using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TripsieCore.Models;

namespace TripsieCore.Migrations
{
    [DbContext(typeof(TripsieContext))]
    [Migration("20170726004542_Tripsie")]
    partial class Tripsie
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

                    b.Property<string>("UserJson");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });
        }
    }
}
