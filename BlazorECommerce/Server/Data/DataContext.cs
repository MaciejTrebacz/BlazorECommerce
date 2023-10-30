namespace BlazorECommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Stir Fry",
                    Url = "StirFry"
                },
                new Category
                {
                    Id = 2,
                    Name = "Salad",
                    Url = "Salad"
                }, new Category
                {
                    Id = 3,
                    Name = "Curry",
                    Url = "Curry"
                },
                new Category
                {
                    Id = 4,
                    Name = "Desserts",
                    Url = "Desserts"
                },
                new Category
                {
                    Id = 5,
                    Name = "Beverages",
                    Url = "Beverages"
                }
                );
            modelBuilder.Entity<Product>().HasData(
                     new Product
                     {
                         Id = 1,
                         Description = "Som tam pla ra is a tasty twist on the classic green papaya salad, hailing all the way from Northeast Thailand. Fermented fish sauce is the key ingredient in this Thai salad",
                         Price = 100,
                         ImageUrl = "https://www.ediblecommunities.com/wp-content/uploads/2019/03/Luke-Nguyen-Street-Food-Asia_-Papaya-salad-900x617.jpg",
                         Title = "Som Tum Pla Ra",
                         CategoryId = 1,

                     },

             new Product
             {
                 Id = 2,
                 Description = "This pad kra pao (pork & holy basil-stir-fry) features a key ingredient: holy basil! With jasmine rice, it’s perfection. And it only takes minutes to make.",
                 Price = 200,
                 ImageUrl = "https://thewoksoflife.com/wp-content/uploads/2016/08/pad-kra-pao-7.jpg",
                 Title = "Pad Kra Pao",
                 CategoryId = 2,
             }, new Product
             {
                 Id = 3,
                 Description = "Thai Green Curry in 30 minutes made by freshening up store bought curry paste OR with a homemade green curry paste! Whichever way you go, the one essential step to make a really great green curry is to fry off the curry paste. ",
                 Price = 500,
                 ImageUrl = "https://www.recipetineats.com/wp-content/uploads/2019/02/Thai-Green-Curry_5.jpg",
                 Title = "GreenCurry",
                 CategoryId = 3,
             }, new Product
             {
                 Id = 4,
                 Description = "Mango sticky rice is a traditional Thai dessert made with glutinous rice, fresh mango and coconut milk, and eaten with a spoon or sometimes the hands.",
                 Price = 120,
                 ImageUrl = "https://elavegan.com/wp-content/uploads/2020/07/drizzling-coconut-sauce-over-mango-sticky-rice.jpg",
                 Title = "Mango Sticky Rice",
                 CategoryId = 4, // Assuming Desserts
             },
            new Product
            {
                Id = 5,
                Description = "Thai iced tea is a Thai drink made from tea, milk and sugar, and served cold. It is popular in Southeast Asia and is served in many restaurants that serve Thai food.",
                Price = 50,
                ImageUrl = "https://hot-thai-kitchen.com/wp-content/uploads/2022/08/Thai-iced-tea.jpg",
                Title = "Thai Iced Tea",
                CategoryId = 5, // Assuming Beverages
            },
            new Product
            {
                Id = 6,
                Description = "Tom yum or tom yam is a type of hot and sour Thai soup, usually cooked with shrimp (prawn). Tom yum has its origin in Thailand.",
                Price = 250,
                ImageUrl = "https://www.recipetineats.com/wp-content/uploads/2019/09/Tom-Yum-soup_2.jpg",
                Title = "Tom Yum Soup",
                CategoryId = 1, // Assuming the first category
            },
            new Product
            {
                Id = 7,
                Description = "Pad Thai is a stir-fried rice noodle dish commonly served as a street food and at most restaurants in Thailand as part of the country's cuisine.",
                Price = 150,
                ImageUrl = "https://www.recipetineats.com/wp-content/uploads/2018/05/Chicken-Pad-Thai_9.jpg",
                Title = "Pad Thai",
                CategoryId = 2, // Assuming the second category
            }




                );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
