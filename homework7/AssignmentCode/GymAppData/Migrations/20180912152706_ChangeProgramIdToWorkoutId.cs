using Microsoft.EntityFrameworkCore.Migrations;

namespace GymAppData.Migrations
{
    public partial class ChangeProgramIdToWorkoutId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Workouts_ProgramId",
                table: "Days");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "Days",
                newName: "WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_Days_ProgramId",
                table: "Days",
                newName: "IX_Days_WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Workouts_WorkoutId",
                table: "Days",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Workouts_WorkoutId",
                table: "Days");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "Days",
                newName: "ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_Days_WorkoutId",
                table: "Days",
                newName: "IX_Days_ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Workouts_ProgramId",
                table: "Days",
                column: "ProgramId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
