using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
            // Your product data here
        };

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(Products);
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
