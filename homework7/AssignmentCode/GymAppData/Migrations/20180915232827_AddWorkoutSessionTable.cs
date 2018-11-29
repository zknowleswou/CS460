using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymAppData.Migrations
{
    public partial class AddWorkoutSessionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "SetRecords",
                newName: "WorkoutSessionId");

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    WorkoutSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Ended = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.WorkoutSessionId);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetRecords_WorkoutSessionId",
                table: "SetRecords",
                column: "WorkoutSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_DayId",
                table: "WorkoutSessions",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_SetRecords_WorkoutSessions_WorkoutSessionId",
                table: "SetRecords",
                column: "WorkoutSessionId",
                principalTable: "WorkoutSessions",
                principalColumn: "WorkoutSessionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetRecords_WorkoutSessions_WorkoutSessionId",
                table: "SetRecords");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_SetRecords_WorkoutSessionId",
                table: "SetRecords");

            migrationBuilder.RenameColumn(
                name: "WorkoutSessionId",
                table: "SetRecords",
                newName: "SessionId");
        }
    }
}
