using System.Net.Http;
using System.Net.Http.Json;
using MiProyectoWeb.Models;
using Proyecto_web_API.Models;

public class ProductoService
{
    private readonly HttpClient _httpClient;

    public ProductoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Producto>> GetProductosAsync() =>
        await _httpClient.GetFromJsonAsync<List<Producto>>("Productos");

    public async Task<Producto> GetProductoAsync(int id) =>
        await _httpClient.GetFromJsonAsync<Producto>($"Productos/{id}");

    public async Task AddProductoAsync(Producto producto) =>
        await _httpClient.PostAsJsonAsync("Productos", producto);

    public async Task UpdateProductoAsync(Producto producto) =>
        await _httpClient.PutAsJsonAsync($"Productos/{producto.Id}", producto);

    public async Task DeleteProductoAsync(int id) =>
        await _httpClient.DeleteAsync($"Productos/{id}");
}

}
