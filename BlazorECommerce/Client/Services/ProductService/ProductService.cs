using BlazorECommerce.Shared;

namespace BlazorECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProductById(int productId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;

        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl is null
                ? await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product")
                : await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            if (result?.Data is not null) Products = result.Data;

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestion(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchSuggestions/{searchText}");
            if (result?.Data is not null) return result.Data;
            Message = "No suggestions found";
            return null;
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
            if (result?.Data is not null) Products = result.Data;
            if (Products.Count == 0) Message = "No products found";
            ProductsChanged.Invoke();
        }
    }
}
