using Microsoft.AspNetCore.Mvc;
using Proyecto_web_API.Models;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Proyecto_web_API.Controllers
{
    public class ProductoController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7032/api");
        }
        public async Task<IActionResult> Index()
        {
           var response = await _httpClient.GetAsync("api/Productos/lista");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var productos = JsonSerializer.Deserialize<IEnumerable<ProductoViewModel>>(content);
                return View("Imdex", productos);
            }

            return View(new List<ProductoViewModel>());

        }
    }
}
