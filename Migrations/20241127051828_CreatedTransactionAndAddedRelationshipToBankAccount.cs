using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesLab1.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTransactionAndAddedRelationshipToBankAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sourceAccNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    operation = table.Column<bool>(type: "bit", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TID);
                    table.ForeignKey(
                        name: "FK_Transactions_BankAccounts_Id",
                        column: x => x.Id,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Id",
                table: "Transactions",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
