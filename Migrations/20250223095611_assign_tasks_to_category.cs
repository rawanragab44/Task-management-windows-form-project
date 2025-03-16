using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationProject.Migrations
{
    /// <inheritdoc />
    public partial class assign_tasks_to_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_CategoryID",
                table: "tasks",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Categories_CategoryID",
                table: "tasks",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Categories_CategoryID",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_CategoryID",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "tasks");
        }
    }
}
