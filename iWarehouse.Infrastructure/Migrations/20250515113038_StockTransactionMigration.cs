using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StockTransactionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "InventoryItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_InventoryItems_ProductNumber",
                table: "InventoryItems",
                column: "ProductNumber");

            migrationBuilder.CreateTable(
                name: "StockTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuantityChange = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerfomedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransactions_InventoryItems_ProductNumber",
                        column: x => x.ProductNumber,
                        principalTable: "InventoryItems",
                        principalColumn: "ProductNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_ProductNumber",
                table: "StockTransactions",
                column: "ProductNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTransactions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_InventoryItems_ProductNumber",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "InventoryItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");
        }
    }
}
