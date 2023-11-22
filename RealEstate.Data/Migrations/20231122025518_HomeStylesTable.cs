using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    /// <inheritdoc />
    public partial class HomeStylesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_HomeStyle_HomeStyleId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "HomeStyle");

            migrationBuilder.CreateTable(
                name: "HomeStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeStyles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_HomeStyles_HomeStyleId",
                table: "Listings",
                column: "HomeStyleId",
                principalTable: "HomeStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_HomeStyles_HomeStyleId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "HomeStyles");

            migrationBuilder.CreateTable(
                name: "HomeStyle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeStyle", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_HomeStyle_HomeStyleId",
                table: "Listings",
                column: "HomeStyleId",
                principalTable: "HomeStyle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
