using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentRental.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rieltor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    FeedbackCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rieltor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    District = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsCount = table.Column<int>(type: "int", nullable: false),
                    FurnitureType = table.Column<int>(type: "int", nullable: false),
                    IsPetFriendly = table.Column<bool>(type: "bit", nullable: false),
                    IsChildFriendly = table.Column<bool>(type: "bit", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    BuildingFloorCount = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PublishingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotosUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: true),
                    RieltorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Apartment_Owner_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owner",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Apartment_Rieltor_RieltorID",
                        column: x => x.RieltorID,
                        principalTable: "Rieltor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_OwnerID",
                table: "Apartment",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_RieltorID",
                table: "Apartment",
                column: "RieltorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Rieltor");
        }
    }
}
