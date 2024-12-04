using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todolist.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "TaskItems",
                type: "bit",
                nullable: false,
                defaultValue: false); // Установка значения по умолчанию
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "TaskItems",
                type: "bit",
                nullable: false,
                defaultValue: null); // Убираем значение по умолчанию при откате
        }
    }
}
