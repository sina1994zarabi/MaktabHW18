using ECommerce.Models;


public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void AddCategory(Category category)
    {
        _categoryRepository.AddCategory(category);
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.DeleteCategory(id);
    }

    public List<Category> GetAllCategories()
    {
        return _categoryRepository.GetAllCategories();
    }

    public Category GetCategoryById(int id)
    {
        return _categoryRepository.GetCategoryById(id);
    }

    public void UpdateCategory(int id, Category updatedCategory)
    {
        _categoryRepository.UpdateCategory(id, updatedCategory);
    }
}
