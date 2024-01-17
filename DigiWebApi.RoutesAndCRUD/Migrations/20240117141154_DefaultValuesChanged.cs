using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiWebApi.RoutesAndCRUD.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValuesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Baguettes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClientId", "Description", "Name", "Price" },
                values: new object[] { 1, "Fait majoritairement avec du beurre.", "Brioche", 1.2f });

            migrationBuilder.InsertData(
                table: "Baguettes",
                columns: new[] { "Id", "ClientId", "Currency", "Description", "Name", "Price" },
                values: new object[] { 4, null, "Euros", "Ça existe au moins ?", "Pain sans gluten", 4.5f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Baguettes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Baguettes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClientId", "Description", "Name", "Price" },
                values: new object[] { null, "Ça existe au moins ?", "Pain sans gluten", 4.5f });
        }
    }
}
