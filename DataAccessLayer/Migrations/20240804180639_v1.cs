using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GovernmentOfficeRegions",
                keyColumn: "GovernmentOfficeRegionId",
                keyValue: 9,
                column: "Description",
                value: "Des9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GovernmentOfficeRegions",
                keyColumn: "GovernmentOfficeRegionId",
                keyValue: 9,
                column: "Description",
                value: "Des8");
        }
    }
}
