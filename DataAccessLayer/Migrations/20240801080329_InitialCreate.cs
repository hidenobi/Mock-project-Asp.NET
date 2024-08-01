using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessTypes",
                columns: table => new
                {
                    BussinessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SICCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTypes", x => x.BussinessID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "ManagerNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    CountyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CountyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.CountyID);
                    table.ForeignKey(
                        name: "FK_Counties_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnownAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StHomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerNameId = table.Column<int>(type: "int", nullable: false),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestContactMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Workbase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_ManagerNames_ManagerNameId",
                        column: x => x.ManagerNameId,
                        principalTable: "ManagerNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentOfficeRegions",
                columns: table => new
                {
                    GovernmentOfficeRegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernmentOfficeRegionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountyId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentOfficeRegions", x => x.GovernmentOfficeRegionId);
                    table.ForeignKey(
                        name: "FK_GovernmentOfficeRegions_Counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "CountyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    TownID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountyID = table.Column<int>(type: "int", nullable: false),
                    TownName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.TownID);
                    table.ForeignKey(
                        name: "FK_Towns_Counties_CountyID",
                        column: x => x.CountyID,
                        principalTable: "Counties",
                        principalColumn: "CountyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programmes_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TownID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_Towns_TownID",
                        column: x => x.TownID,
                        principalTable: "Towns",
                        principalColumn: "TownID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TownID",
                table: "Addresses",
                column: "TownID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTypes_BusinessName",
                table: "BusinessTypes",
                column: "BusinessName");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ManagerNameId",
                table: "Contacts",
                column: "ManagerNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Counties_CountryID",
                table: "Counties",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentOfficeRegions_CountyId",
                table: "GovernmentOfficeRegions",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_ContactId",
                table: "Programmes",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_CountyID",
                table: "Towns",
                column: "CountyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BusinessTypes");

            migrationBuilder.DropTable(
                name: "GovernmentOfficeRegions");

            migrationBuilder.DropTable(
                name: "Programmes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropTable(
                name: "ManagerNames");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
