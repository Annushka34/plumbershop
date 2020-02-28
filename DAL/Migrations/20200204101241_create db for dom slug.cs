using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class createdbfordomslug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Posts",
                newName: "Img");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Goods",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Goods",
                newName: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Goods",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Goods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Goods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_PostId",
                table: "Goods",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_UserId",
                table: "Goods",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Posts_PostId",
                table: "Goods",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_User_UserId",
                table: "Goods",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_User_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Posts_PostId",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_Goods_User_UserId",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_User_UserId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Goods_PostId",
                table: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Goods_UserId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "Img",
                table: "Posts",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Goods",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Goods",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Goods",
                nullable: true);
        }
    }
}
