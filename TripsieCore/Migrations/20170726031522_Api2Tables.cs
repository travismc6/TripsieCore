using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TripsieCore.Migrations
{
    public partial class Api2Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Trips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TripUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsCreator = table.Column<bool>(nullable: false),
                    Lat = table.Column<long>(nullable: false),
                    Lon = table.Column<long>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    TripCode = table.Column<string>(nullable: true),
                    TripId = table.Column<int>(nullable: true),
                    TripStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripUser_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DetailId = table.Column<int>(nullable: false),
                    TripUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripComment_TripUser_TripUserId",
                        column: x => x.TripUserId,
                        principalTable: "TripUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripComment_TripUserId",
                table: "TripComment",
                column: "TripUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TripUser_TripId",
                table: "TripUser",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripComment");

            migrationBuilder.DropTable(
                name: "TripUser");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Trips");
        }
    }
}
