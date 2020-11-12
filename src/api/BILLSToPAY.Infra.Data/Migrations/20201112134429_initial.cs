using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BILLSToPAY.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Days = table.Column<int>(nullable: false),
                    Type = table.Column<short>(nullable: false),
                    InterestPerDay = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Penalty = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    OriginalValue = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    CorrectedValue = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    NumberOfDaysLate = table.Column<int>(nullable: false),
                    RuleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Rule_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RuleId",
                table: "Account",
                column: "RuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Rule");
        }
    }
}
