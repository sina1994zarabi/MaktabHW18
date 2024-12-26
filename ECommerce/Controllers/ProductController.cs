using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;


public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetAllProducts();
        return View(products);
    }
    public IActionResult Details(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = _categoryService.GetAllCategories();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product newProduct)
    {
        if (InMemoryDb.Currentuser == null) return RedirectToAction("Login", "User");
        ModelState.Remove(nameof(newProduct.ID));
        ModelState.Remove(nameof(newProduct.category));
        if (ModelState.IsValid) 
        {
            _productService.AddProduct(newProduct);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = _categoryService.GetAllCategories();
        return View(newProduct);
    }

    public IActionResult Edit(int id)
    {
        if (InMemoryDb.Currentuser == null) return RedirectToAction("Login", "User");
        var product = _productService.GetProductById(id);
        if (product == null) return NotFound();
        ViewBag.Categories = _categoryService.GetAllCategories();
        return View(product);
    }

    [HttpPost,ActionName("Edit")]
    public IActionResult UpdateProduct(int id, Product updatedProduct)
    {
        if (InMemoryDb.Currentuser == null)
        { 
            return RedirectToAction("Login", "Account");
        }
        if (id != updatedProduct.ID) 
        {
            return NotFound();
        }
        if (ModelState.IsValid) 
        { 
            _productService.UpdateProduct(id,updatedProduct);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = _categoryService.GetAllCategories();
        return View(updatedProduct);
    }

    public IActionResult Delete(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _productService.DeleteProduct(id);
        return RedirectToAction("Index");
    }
}


