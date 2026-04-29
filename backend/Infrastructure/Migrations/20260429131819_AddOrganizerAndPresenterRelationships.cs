using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizerAndPresenterRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AikidoEvents_OrganizerId",
                table: "AikidoEvents",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_AikidoEvents_PresenterId",
                table: "AikidoEvents",
                column: "PresenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AikidoEvents_Members_OrganizerId",
                table: "AikidoEvents",
                column: "OrganizerId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AikidoEvents_Members_PresenterId",
                table: "AikidoEvents",
                column: "PresenterId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AikidoEvents_Members_OrganizerId",
                table: "AikidoEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_AikidoEvents_Members_PresenterId",
                table: "AikidoEvents");

            migrationBuilder.DropIndex(
                name: "IX_AikidoEvents_OrganizerId",
                table: "AikidoEvents");

            migrationBuilder.DropIndex(
                name: "IX_AikidoEvents_PresenterId",
                table: "AikidoEvents");
        }
    }
}
