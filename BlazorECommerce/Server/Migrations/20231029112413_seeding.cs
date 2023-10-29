using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Som tam pla ra is a tasty twist on the classic green papaya salad, hailing all the way from Northeast Thailand. Fermented fish sauce is the key ingredient in this Thai salad", "https://www.ediblecommunities.com/wp-content/uploads/2019/03/Luke-Nguyen-Street-Food-Asia_-Papaya-salad-900x617.jpg", 100m, "Som Tum Pla Ra" },
                    { 2, "This pad kra pao (pork & holy basil-stir-fry) features a key ingredient: holy basil! With jasmine rice, it’s perfection. And it only takes minutes to make.", "https://thewoksoflife.com/wp-content/uploads/2016/08/pad-kra-pao-7.jpg", 200m, "Pad Kra Pao" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
