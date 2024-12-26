using ECommerce.Models;



public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public void AddProduct(Product newProduct)
    {
        _productRepository.AddProduct(newProduct);
    }

   public void UpdateProduct(int id,Product updatedProduct)
    {
        _productRepository.UpdateProduct(id,updatedProduct);
    }

    public void DeleteProduct(int id)
    {
        _productRepository.DeleteProduct(id);
    }
}