﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace BlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
        {
            return Ok(await _productService.GetProductsAsync());
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductByIdAsync(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            return Ok(await _productService.GetProductsByCategory(categoryUrl));
        }

        [HttpGet("search/{searchFilter}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetSearchProducts(string searchFilter)
        {
            return Ok(await _productService.SearchProducts(searchFilter));
        }

        [HttpGet("searchSuggestions/{searchFilter}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetSearchSuggestions(string searchFilter)
        {
            return Ok(await _productService.SuggestProduct(searchFilter));
        }

        [HttpGet]
        [Route("getExcel")]
        public async Task<IActionResult> GetExcel()
        {
            byte[] excelData = GetExcelData();
            if (excelData is null) return BadRequest("Excel data not loaded correctly.");

            var jsonData = ConvertExcelToJSON(excelData);
            return Ok(jsonData);
        }

        [HttpGet]
        [Route("getExcelFile")]
        public async Task<IActionResult> GetExcelFile()
        {
            byte[] excelData = GetExcelData();
            if (excelData is null) return BadRequest("Excel file not generated correctly");

            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "example.xlsx";

            return File(excelData, contentType, fileName);
        }

        private string ConvertExcelToJSON(byte[] excelData)
        {
            using (var package = new ExcelPackage(new MemoryStream(excelData)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var data = new List<Dictionary<string, string>>();
                var headers = new List<string>();

                var headerRow = worksheet.Cells["1:1"];
                foreach (var cell in headerRow)
                {
                    headers.Add(cell.Text);
                }

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var rowData = new Dictionary<string, string>();
                    for (int col = 1; col <= headers.Count; col++)
                    {
                        rowData[headers[col - 1]] = worksheet.Cells[row, col].Text;
                    }
                    data.Add(rowData);
                }
                return JsonConvert.SerializeObject(data);
            }
        }

        private byte[] GetExcelData()
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // add headers
                worksheet.Cells["A1"].Value = "Name";
                worksheet.Cells["B1"].Value = "Age";
                worksheet.Cells["C1"].Value = "Country";

                // add sample data
                worksheet.Cells["A2"].Value = "John";
                worksheet.Cells["B2"].Value = 30;
                worksheet.Cells["C2"].Value = "USA";
                worksheet.Cells["A3"].Value = "John";
                worksheet.Cells["B3"].Value = 30;
                worksheet.Cells["C3"].Value = "USA";
                var excelBytes = package.GetAsByteArray();

                return excelBytes;
            }
        }
    }
}
