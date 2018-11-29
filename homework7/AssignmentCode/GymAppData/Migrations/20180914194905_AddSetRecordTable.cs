using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymAppData.Migrations
{
    public partial class AddSetRecordTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetRecords",
                columns: table => new
                {
                    SetRecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SetId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    GoalRepititions = table.Column<int>(nullable: false),
                    CompletedRepititions = table.Column<int>(nullable: false),
                    GoalWeight = table.Column<decimal>(nullable: false),
                    CompletedWeight = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Updated = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetRecords", x => x.SetRecordId);
                    table.ForeignKey(
                        name: "FK_SetRecords_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "SetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetRecords_SetId",
                table: "SetRecords",
                column: "SetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetRecords");
        }
    }
}
