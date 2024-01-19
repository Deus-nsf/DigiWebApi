using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiWebApi.RoutesAndCRUD.Migrations
{
    /// <inheritdoc />
    public partial class JoinTableBaguetteClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baguettes_Clients_ClientId",
                table: "Baguettes");

            migrationBuilder.DropIndex(
                name: "IX_Baguettes_ClientId",
                table: "Baguettes");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Baguettes");

            migrationBuilder.CreateTable(
                name: "BaguetteClient",
                columns: table => new
                {
                    BaguettesId = table.Column<int>(type: "int", nullable: false),
                    ClientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaguetteClient", x => new { x.BaguettesId, x.ClientsId });
                    table.ForeignKey(
                        name: "FK_BaguetteClient_Baguettes_BaguettesId",
                        column: x => x.BaguettesId,
                        principalTable: "Baguettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaguetteClient_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaguetteClient_ClientsId",
                table: "BaguetteClient",
                column: "ClientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaguetteClient");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Baguettes",
                type: "int",
                nullable: true);

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
                value: 1);

            migrationBuilder.UpdateData(
                table: "Baguettes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClientId",
                value: null);

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
    }
}
