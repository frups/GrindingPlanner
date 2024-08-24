using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrindingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekPlan",
                columns: table => new
                {
                    WeekPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false),
                    WeekPlanFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    WeekPlanTo = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekPlan", x => x.WeekPlanId);
                    table.ForeignKey(
                        name: "FK_WeekPlan_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "TrainingPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekPlan_TrainingPlanId",
                table: "WeekPlan",
                column: "TrainingPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekPlan");
        }
    }
}
