using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService){
            _categoryService = categoryService;
        }
        public IActionResult Index()
        { 
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }
        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            if (ModelState.IsValid) 
            {
                _categoryService.AddCategory(newCategory);
                return RedirectToAction("Index");
            } 
            return View(newCategory);
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            } 
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(int id, Category updatedCategory)
        { 
            if (id != updatedCategory.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            { 
                _categoryService.UpdateCategory(id, updatedCategory);
                return RedirectToAction("Index");
            }
            return View(updatedCategory);
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmation(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}

