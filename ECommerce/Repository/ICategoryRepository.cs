using ECommerce.Models;


public interface ICategoryRepository
{
    List<Category> GetAllCategories();
    Category GetCategoryById(int id);
    void AddCategory(Category newCategory);
    void UpdateCategory(int id, Category updatedCategory);
    void DeleteCategory(int id);
}

