using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class Categories2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 4, "Desserts", "Desserts" },
                    { 5, "Beverages", "Beverages" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 6, 1, "Tom yum or tom yam is a type of hot and sour Thai soup, usually cooked with shrimp (prawn). Tom yum has its origin in Thailand.", "https://www.recipetineats.com/wp-content/uploads/2019/09/Tom-Yum-soup_2.jpg", 250m, "Tom Yum Soup" },
                    { 7, 2, "Pad Thai is a stir-fried rice noodle dish commonly served as a street food and at most restaurants in Thailand as part of the country's cuisine.", "https://www.recipetineats.com/wp-content/uploads/2018/05/Chicken-Pad-Thai_9.jpg", 150m, "Pad Thai" },
                    { 4, 4, "Mango sticky rice is a traditional Thai dessert made with glutinous rice, fresh mango and coconut milk, and eaten with a spoon or sometimes the hands.", "https://elavegan.com/wp-content/uploads/2020/07/drizzling-coconut-sauce-over-mango-sticky-rice.jpg", 120m, "Mango Sticky Rice" },
                    { 5, 5, "Thai iced tea is a Thai drink made from tea, milk and sugar, and served cold. It is popular in Southeast Asia and is served in many restaurants that serve Thai food.", "https://hot-thai-kitchen.com/wp-content/uploads/2022/08/Thai-iced-tea.jpg", 50m, "Thai Iced Tea" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
