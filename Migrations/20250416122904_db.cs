using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "FeedBack",
                table: "ExamResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Points",
                table: "ExamQuestions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedBack",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "ExamQuestions");

            migrationBuilder.AddColumn<double>(
                name: "Points",
                table: "Questions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
