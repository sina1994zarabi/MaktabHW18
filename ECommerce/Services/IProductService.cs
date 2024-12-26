using ECommerce.Models;


public interface IProductService
{
    List<Product> GetAllProducts();
    Product GetProductById(int id);
    void AddProduct(Product newProduct);
    void UpdateProduct(int id, Product updatedProduct);
    void DeleteProduct(int id);
}