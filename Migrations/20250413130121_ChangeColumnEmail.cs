using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iBanking.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_email",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_email",
                table: "Customers",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_email",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_email",
                table: "Customers",
                column: "email",
                unique: true);
        }
    }
}
