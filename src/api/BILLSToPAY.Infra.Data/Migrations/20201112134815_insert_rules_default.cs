using Microsoft.EntityFrameworkCore.Migrations;

namespace BILLSToPAY.Infra.Data.Migrations
{
    public partial class insert_rules_default : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [RULE](ID, Days, Type, InterestPerDay, Penalty, Active)
                                   values (NEWID(), 3, 1, 0.1, 2, 1)");
            migrationBuilder.Sql(@"INSERT INTO [RULE](ID, Days, Type, InterestPerDay, Penalty, Active)
                                   values (NEWID(), 3, 2, 0.2, 3, 1)");
            migrationBuilder.Sql(@"INSERT INTO [RULE](ID, Days, Type, InterestPerDay, Penalty, Active)
                                   values (NEWID(), 5, 2, 0.3, 5, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM RULE");
        }
    }
}
