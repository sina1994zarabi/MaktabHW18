using ECommerce.Models;

public interface IProductRepository
{
    void AddProduct(Product newProduct);
    List<Product> GetAllProducts();
    Product GetProductById(int id);
    void UpdateProduct(int id,Product product);
    void DeleteProduct(int id);    
}