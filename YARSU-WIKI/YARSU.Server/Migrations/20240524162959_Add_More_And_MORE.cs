using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YARSU.Server.Migrations
{
    /// <inheritdoc />
    public partial class Add_More_And_MORE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pages_PageId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "PageId",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pages_PageId",
                table: "Comments",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pages_PageId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "PageId",
                table: "Comments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pages_PageId",
                table: "Comments",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id");
        }
    }
}
