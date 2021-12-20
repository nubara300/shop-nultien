using Microsoft.EntityFrameworkCore.Migrations;

namespace NultienShop.DataAccess.Domain.Migrations
{
    public partial class InitialDataChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 1,
                column: "ArticleQuantity",
                value: 500);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 2,
                column: "ArticleQuantity",
                value: 300);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 3,
                column: "ArticleQuantity",
                value: 200);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 4,
                column: "ArticleQuantity",
                value: 700);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 5,
                column: "ArticleQuantity",
                value: 2700);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 6,
                column: "ArticleQuantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 7,
                column: "ArticleQuantity",
                value: 1170);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 8,
                column: "ArticleQuantity",
                value: 206);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 9,
                column: "ArticleQuantity",
                value: 758);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 10,
                column: "ArticleQuantity",
                value: 789);

            migrationBuilder.InsertData(
                table: "InventoryArticle",
                columns: new[] { "InventoryArticleId", "ArticleId", "ArticleQuantity", "InventoryId" },
                values: new object[,]
                {
                    { 20, 10, 0, 1 },
                    { 18, 8, 77, 3 },
                    { 17, 7, 332, 4 },
                    { 16, 6, 2700, 5 },
                    { 15, 5, 50, 6 },
                    { 14, 4, 1170, 7 },
                    { 13, 3, 206, 8 },
                    { 12, 2, 758, 9 },
                    { 19, 9, 10, 2 },
                    { 11, 1, 650, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 1,
                column: "ArticleQuantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 2,
                column: "ArticleQuantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 3,
                column: "ArticleQuantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 4,
                column: "ArticleQuantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 5,
                column: "ArticleQuantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 6,
                column: "ArticleQuantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 7,
                column: "ArticleQuantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 8,
                column: "ArticleQuantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 9,
                column: "ArticleQuantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryArticle",
                keyColumn: "InventoryArticleId",
                keyValue: 10,
                column: "ArticleQuantity",
                value: 0);
        }
    }
}
