namespace BlazorECommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                     new Product
                     {
                         Id = 1,
                         Description = "Som tam pla ra is a tasty twist on the classic green papaya salad, hailing all the way from Northeast Thailand. Fermented fish sauce is the key ingredient in this Thai salad",
                         Price = 100,
                         ImageUrl = "https://www.ediblecommunities.com/wp-content/uploads/2019/03/Luke-Nguyen-Street-Food-Asia_-Papaya-salad-900x617.jpg",
                         Title = "Som Tum Pla Ra"
                     },

             new Product
             {
                 Id = 2,
                 Description = "This pad kra pao (pork & holy basil-stir-fry) features a key ingredient: holy basil! With jasmine rice, it’s perfection. And it only takes minutes to make.",
                 Price = 200,
                 ImageUrl = "https://thewoksoflife.com/wp-content/uploads/2016/08/pad-kra-pao-7.jpg",
                 Title = "Pad Kra Pao"
             }
                );
        }

        public DbSet<Product> Products { get; set; }
    }
}
