using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Purse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyRate = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    CompinyNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purse",
                columns: table => new
                {
                    PurseId = table.Column<int>(type: "int", nullable: false),
                    PurseBalance = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    PurseKind = table.Column<int>(type: "int", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purse", x => x.PurseId);
                    table.ForeignKey(
                        name: "FK_Purse_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionKind = table.Column<int>(type: "int", nullable: false),
                    TransactionStatus = table.Column<int>(type: "int", nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    transactionValue = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    PurseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_Purse_PurseId",
                        column: x => x.PurseId,
                        principalTable: "Purse",
                        principalColumn: "PurseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voacher",
                columns: table => new
                {
                    VoacherId = table.Column<int>(type: "int", nullable: false),
                    PurseSourceId = table.Column<int>(type: "int", nullable: false),
                    PurseDestinationID = table.Column<int>(type: "int", nullable: false),
                    VoacherTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoacherStatus = table.Column<int>(type: "int", nullable: false),
                    VoacherValue = table.Column<float>(type: "real", nullable: false, defaultValue: 0f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voacher", x => x.VoacherId);
                    table.ForeignKey(
                        name: "FK_Voacher_Purse_PurseDestinationID",
                        column: x => x.PurseDestinationID,
                        principalTable: "Purse",
                        principalColumn: "PurseId");
                    table.ForeignKey(
                        name: "FK_Voacher_Purse_PurseSourceId",
                        column: x => x.PurseSourceId,
                        principalTable: "Purse",
                        principalColumn: "PurseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purse_UserId",
                table: "Purse",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PurseId",
                table: "Transaction",
                column: "PurseId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyID",
                table: "User",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Voacher_PurseDestinationID",
                table: "Voacher",
                column: "PurseDestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_Voacher_PurseSourceId",
                table: "Voacher",
                column: "PurseSourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Voacher");

            migrationBuilder.DropTable(
                name: "Purse");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
