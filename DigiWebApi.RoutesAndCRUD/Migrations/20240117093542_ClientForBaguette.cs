using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigiWebApi.RoutesAndCRUD.Migrations
{
    /// <inheritdoc />
    public partial class ClientForBaguette : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Baguettes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Baguettes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClientId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Baguettes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClientId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Baguettes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClientId",
                value: null);

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "432 avenue de la Gourmandise", "Marie Madelaine" },
                    { 2, "123 rue de la Jean-Michelerie", "Jean Michel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baguettes_ClientId",
                table: "Baguettes",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baguettes_Clients_ClientId",
                table: "Baguettes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baguettes_Clients_ClientId",
                table: "Baguettes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Baguettes_ClientId",
                table: "Baguettes");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Baguettes");
        }
    }
}
