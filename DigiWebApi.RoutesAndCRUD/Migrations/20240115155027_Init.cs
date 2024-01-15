using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigiWebApi.RoutesAndCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baguettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baguettes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Baguettes",
                columns: new[] { "Id", "Currency", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Euros", "Du pain artisanal à la farine de blé complet.", "Pain complet", 2.5f },
                    { 2, "Euros", "Du pain artisanal à la farine blanche et plein de glucose !", "Baguette tradition", 1.2f },
                    { 3, "Euros", "Ça existe au moins ?", "Pain sans gluten", 4.5f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baguettes");
        }
    }
}
