using Microsoft.AspNetCore.Mvc;
using MiProyectoWeb.Models;
using MiProyectoWeb.Services;
using Proyecto_web_API.Models;

public class ProductoController : Controller
{
    private readonly ProductoService _productoService;

    public ProductoController(ProductoService productoService)
    {
        _productoService = productoService;
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _productoService.GetProductosAsync();
        return View(productos);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Producto producto)
    {
        await _productoService.AddProductoAsync(producto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var producto = await _productoService.GetProductoAsync(id);
        if (producto == null) return NotFound();
        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Producto producto)
    {
        await _productoService.UpdateProductoAsync(producto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var producto = await _productoService.GetProductoAsync(id);
        if (producto == null) return NotFound(); return View(producto);
    }

}

