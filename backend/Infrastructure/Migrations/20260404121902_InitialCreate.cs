using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AikidoEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizerId = table.Column<int>(type: "int", nullable: true),
                    PresenterId = table.Column<int>(type: "int", nullable: true),
                    AttendeesIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AikidoEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresidentId = table.Column<int>(type: "int", nullable: false),
                    Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dojos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DojoChoId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dojos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dojos_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInfo_Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInfo_Address_StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInfo_Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInfo_Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalInfo_Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInfo_Contact_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInfo_DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PersonalInfo_ParentName_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalInfo_ParentName_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraineeInfo_Rank = table.Column<int>(type: "int", nullable: false),
                    TraineeInfo_Belt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeInfo_Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeInfo_DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraineeInfo_AikidoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DojoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Dojos_DojoId",
                        column: x => x.DojoId,
                        principalTable: "Dojos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventAttendees",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendees", x => new { x.EventId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_EventAttendees_AikidoEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "AikidoEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventAttendees_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeInfoMemberId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => new { x.TraineeInfoMemberId, x.Id });
                    table.ForeignKey(
                        name: "FK_Note_Members_TraineeInfoMemberId",
                        column: x => x.TraineeInfoMemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dojos_DojoChoId",
                table: "Dojos",
                column: "DojoChoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dojos_OrganizationId",
                table: "Dojos",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_MemberId",
                table: "EventAttendees",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_DojoId",
                table: "Members",
                column: "DojoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dojos_Members_DojoChoId",
                table: "Dojos",
                column: "DojoChoId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dojos_Members_DojoChoId",
                table: "Dojos");

            migrationBuilder.DropTable(
                name: "EventAttendees");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "AikidoEvents");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Dojos");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
