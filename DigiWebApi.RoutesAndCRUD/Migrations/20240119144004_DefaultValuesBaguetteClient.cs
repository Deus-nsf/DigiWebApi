using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigiWebApi.RoutesAndCRUD.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValuesBaguetteClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BaguetteClient",
                columns: new[] { "BaguettesId", "ClientsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Baguettes",
                columns: new[] { "Id", "Currency", "Description", "Name", "Price" },
                values: new object[] { 5, "Euros", "Ça existe au moins ?", "Pain Test", 4.5f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BaguetteClient",
                keyColumns: new[] { "BaguettesId", "ClientsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BaguetteClient",
                keyColumns: new[] { "BaguettesId", "ClientsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BaguetteClient",
                keyColumns: new[] { "BaguettesId", "ClientsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Baguettes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
