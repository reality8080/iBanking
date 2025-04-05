using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iBanking.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    idCus = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cccd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.idCus);
                });

            migrationBuilder.CreateTable(
                name: "BankAccs",
                columns: table => new
                {
                    idAcc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idCus = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    typeAcc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    currBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    openDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccs", x => x.idAcc);
                    table.ForeignKey(
                        name: "FK_BankAccs_Customers_idCus",
                        column: x => x.idCus,
                        principalTable: "Customers",
                        principalColumn: "idCus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    idCard = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idAcc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    numberCard = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    expiredCard = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statusCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => x.idCard);
                    table.ForeignKey(
                        name: "FK_BankCards_BankAccs_idAcc",
                        column: x => x.idAcc,
                        principalTable: "BankAccs",
                        principalColumn: "idAcc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    idLoan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idAcc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    term = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.idLoan);
                    table.ForeignKey(
                        name: "FK_Loans_BankAccs_idAcc",
                        column: x => x.idAcc,
                        principalTable: "BankAccs",
                        principalColumn: "idAcc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    idTransaction = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idAcc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeTrans = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    money = table.Column<double>(type: "float", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.idTransaction);
                    table.ForeignKey(
                        name: "FK_Transactions_BankAccs_idAcc",
                        column: x => x.idAcc,
                        principalTable: "BankAccs",
                        principalColumn: "idAcc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAuths",
                columns: table => new
                {
                    idUserAuth = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idAcc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    typeAuth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuths", x => x.idUserAuth);
                    table.ForeignKey(
                        name: "FK_UserAuths_BankAccs_idAcc",
                        column: x => x.idAcc,
                        principalTable: "BankAccs",
                        principalColumn: "idAcc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccs_idCus",
                table: "BankAccs",
                column: "idCus");

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_idAcc",
                table: "BankCards",
                column: "idAcc");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_phone",
                table: "Customers",
                column: "phone");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_idAcc",
                table: "Loans",
                column: "idAcc");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_idAcc",
                table: "Transactions",
                column: "idAcc");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuths_idAcc",
                table: "UserAuths",
                column: "idAcc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserAuths");

            migrationBuilder.DropTable(
                name: "BankAccs");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
