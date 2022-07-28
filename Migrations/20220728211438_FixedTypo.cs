using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bugtracker.Migrations
{
    public partial class FixedTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeModifed",
                table: "Issue",
                newName: "DateTimeModified");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "JointUserIssue",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "IssueId",
                table: "JointUserIssue",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_JointUserIssue_IssueId",
                table: "JointUserIssue",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_JointUserIssue_UserId",
                table: "JointUserIssue",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JointUserIssue_Issue_IssueId",
                table: "JointUserIssue",
                column: "IssueId",
                principalTable: "Issue",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JointUserIssue_User_UserId",
                table: "JointUserIssue",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JointUserIssue_Issue_IssueId",
                table: "JointUserIssue");

            migrationBuilder.DropForeignKey(
                name: "FK_JointUserIssue_User_UserId",
                table: "JointUserIssue");

            migrationBuilder.DropIndex(
                name: "IX_JointUserIssue_IssueId",
                table: "JointUserIssue");

            migrationBuilder.DropIndex(
                name: "IX_JointUserIssue_UserId",
                table: "JointUserIssue");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "Issue",
                newName: "DateTimeModifed");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "JointUserIssue",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IssueId",
                table: "JointUserIssue",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
