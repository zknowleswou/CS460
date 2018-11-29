using Microsoft.EntityFrameworkCore.Migrations;

namespace GymAppData.Migrations
{
    public partial class ChangeProgramToWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "Workouts",
                newName: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "Workouts",
                newName: "ProgramId");
        }
    }
}
