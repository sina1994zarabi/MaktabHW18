using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
public class ProductRepository : IProductRepository
{
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.category).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include(p => p.category).FirstOrDefault(p => p.ID == id);
        }

        public void AddProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public void UpdateProduct(int id,Product updatedProduct)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                product.Title = updatedProduct.Title;
                product.Description = updatedProduct.Description;
                product.categoryId = updatedProduct.categoryId;
                _context.SaveChanges();   
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
}