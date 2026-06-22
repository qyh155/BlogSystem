using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "Users",
                type: "text",
                nullable: true,
                defaultValue: "/Avatar/default.png",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "DispalyOrder", "Name" },
                values: new object[,]
                {
                    { 1, "", 0, "技术" },
                    { 2, "", 0, "生活" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "技术" },
                    { 2, "生活" },
                    { 3, "工作" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastLoginAt", "PasswordHash", "UserName" },
                values: new object[] { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@Blog.com", null, "留空", "admin" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CoverImageUrl", "CreatedAt", "IsDeleted", "Ispublished", "LikeCount", "Summary", "Title", "UpdatedAt", "UserId", "UserId1", "ViewCount" },
                values: new object[] { 1, 1, "这是我的第一篇文章，欢迎大家阅读！", "https://picsum.photos/800/400", new DateTime(2026, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), false, true, 5, "开篇", "欢迎来到我的博客", new DateTime(2026, 1, 1, 12, 1, 1, 1, DateTimeKind.Utc), 1, null, 50 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "AuthorName", "Content", "CreatedAt", "IsApproved", "ParentId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "张三", "文章写的很好", new DateTime(2026, 1, 1, 12, 2, 2, 0, DateTimeKind.Utc), true, null, null },
                    { 2, 1, "李四", "期待下一篇分享", new DateTime(2026, 1, 1, 13, 2, 2, 0, DateTimeKind.Utc), true, null, null },
                    { 3, 1, "李四", "说的不错", new DateTime(2026, 1, 1, 13, 3, 2, 0, DateTimeKind.Utc), true, 1, null },
                    { 4, 1, "张三", "谢谢", new DateTime(2026, 1, 1, 13, 3, 2, 0, DateTimeKind.Utc), true, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "/Avatar/default.png");
        }
    }
}
