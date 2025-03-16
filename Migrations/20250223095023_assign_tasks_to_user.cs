using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationProject.Migrations
{
    /// <inheritdoc />
    public partial class assign_tasks_to_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_UserID",
                table: "tasks",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_users_UserID",
                table: "tasks",
                column: "UserID",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_users_UserID",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_UserID",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "tasks");
        }
    }
}
