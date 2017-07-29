using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TripsieCore.Migrations
{
    public partial class Api2Tables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripComment_TripUser_TripUserId",
                table: "TripComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TripUser_Trips_TripId",
                table: "TripUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripUser",
                table: "TripUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripComment",
                table: "TripComment");

            migrationBuilder.RenameTable(
                name: "TripUser",
                newName: "TripUsers");

            migrationBuilder.RenameTable(
                name: "TripComment",
                newName: "TripComments");

            migrationBuilder.RenameIndex(
                name: "IX_TripUser_TripId",
                table: "TripUsers",
                newName: "IX_TripUsers_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_TripComment_TripUserId",
                table: "TripComments",
                newName: "IX_TripComments_TripUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripUsers",
                table: "TripUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripComments",
                table: "TripComments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PushRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationId = table.Column<string>(nullable: true),
                    TripUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PushRegistrations_TripUsers_TripUserId",
                        column: x => x.TripUserId,
                        principalTable: "TripUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    Lat = table.Column<long>(nullable: false),
                    Lon = table.Column<long>(nullable: false),
                    TripId = table.Column<int>(nullable: false),
                    TripUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripActivities_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityVotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripActivityId = table.Column<int>(nullable: false),
                    TripUserId = table.Column<int>(nullable: false),
                    Vote = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityVotes_TripActivities_TripActivityId",
                        column: x => x.TripActivityId,
                        principalTable: "TripActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityVotes_TripUsers_TripUserId",
                        column: x => x.TripUserId,
                        principalTable: "TripUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityVotes_TripActivityId",
                table: "ActivityVotes",
                column: "TripActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityVotes_TripUserId",
                table: "ActivityVotes",
                column: "TripUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PushRegistrations_TripUserId",
                table: "PushRegistrations",
                column: "TripUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TripActivities_TripId",
                table: "TripActivities",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripComments_TripUsers_TripUserId",
                table: "TripComments",
                column: "TripUserId",
                principalTable: "TripUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripUsers_Trips_TripId",
                table: "TripUsers",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripComments_TripUsers_TripUserId",
                table: "TripComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TripUsers_Trips_TripId",
                table: "TripUsers");

            migrationBuilder.DropTable(
                name: "ActivityVotes");

            migrationBuilder.DropTable(
                name: "PushRegistrations");

            migrationBuilder.DropTable(
                name: "TripActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripUsers",
                table: "TripUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripComments",
                table: "TripComments");

            migrationBuilder.RenameTable(
                name: "TripUsers",
                newName: "TripUser");

            migrationBuilder.RenameTable(
                name: "TripComments",
                newName: "TripComment");

            migrationBuilder.RenameIndex(
                name: "IX_TripUsers_TripId",
                table: "TripUser",
                newName: "IX_TripUser_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_TripComments_TripUserId",
                table: "TripComment",
                newName: "IX_TripComment_TripUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripUser",
                table: "TripUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripComment",
                table: "TripComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TripComment_TripUser_TripUserId",
                table: "TripComment",
                column: "TripUserId",
                principalTable: "TripUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripUser_Trips_TripId",
                table: "TripUser",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
