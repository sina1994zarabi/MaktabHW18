using ECommerce.Models;


public interface ICategoryService
{
    List<Category> GetAllCategories();
    Category GetCategoryById(int id);
    void AddCategory(Category category);
    void UpdateCategory(int id, Category category);
    void DeleteCategory(int id);
}

