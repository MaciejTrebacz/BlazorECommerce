namespace BlazorECommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<Product>> GetProductById(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _dataContext.Products
                .Include(x=>x.Variants)
                .ThenInclude(x=>x.ProductType)
                .FirstOrDefaultAsync(x=>x.Id == productId);
            if (product is null) { 
                response.Success = false;
                response.Message = "Sorry, but this product does not exist";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _dataContext.Products
                .Include(x=>x.Variants)
                .ThenInclude(x=>x.ProductType)
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _dataContext.Products
                .Include(x=>x.Variants)
                .ThenInclude(x=>x.ProductType)
                .Where(x => x.Category.Url.ToLower() == categoryUrl.ToLower())
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _dataContext.Products
                .Where(x => x.Title.ToLower()
                .Contains(searchText.ToLower()) 
                || x.Description.ToLower()
                .Contains(searchText.ToLower()))
                .Include(x=>x.Variants)
                .ToListAsync(),
            };
            return response;
        }

        public async Task<ServiceResponse<List<string>>> SuggestProduct(string searchText)
        {
            var response = new ServiceResponse<List<string>>()
            {
                Data = await _dataContext.Products
                .Where(x => x.Title.ToLower().Contains(searchText.ToLower())
                    || x.Description.ToLower().Contains(searchText.ToLower()))
                .Select(x => x.Title).ToListAsync(),
            };
            return response;
        }
    }
}
