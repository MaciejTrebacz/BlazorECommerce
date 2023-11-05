﻿namespace BlazorECommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient) {
            _httpClient = httpClient;
        }
        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategoriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            if (response?.Data is not null) Categories = response.Data;  
        }
    }
}
