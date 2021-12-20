using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NultienShop.DataAccess.Domain.Migrations
{
    public partial class ArticleProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames =
                assembly.GetManifestResourceNames()
                    .Where(str => str.Contains("SelectArticleQuantity.sql"));

            foreach (string resourceName in resourceNames)
            {
                using Stream stream = assembly.GetManifestResourceStream(resourceName);
                using StreamReader reader = new(stream);
                string sql = reader.ReadToEnd();
                migrationBuilder.Sql(sql);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE SelectArticleQuantity");
        }
    }
}
