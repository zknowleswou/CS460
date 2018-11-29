using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymAppData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    ProgramId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProgramId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    IsRestDay = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Updated = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                    table.ForeignKey(
                        name: "FK_Days_Workouts_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Workouts",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Updated = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    SetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExerciseId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Repititions = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Updated = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.SetId);
                    table.ForeignKey(
                        name: "FK_Sets_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Days_ProgramId",
                table: "Days",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_DayId",
                table: "Exercises",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_ExerciseId",
                table: "Sets",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
