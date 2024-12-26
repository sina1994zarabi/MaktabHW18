using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;

public static class InMemoryDb
{
    public static User Currentuser { get; set; }

    public static void SeedData(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()
            ))
        {
            if (context.Products.Any() &&
                context.Users.Any() &&
                context.Categories.Any()) return;
            context.Categories.AddRange(
                new Category { Name = "Electronics"},
                new Category { Name = "Food"},
                new Category { Name = "Media"},
                new Category { Name = "Fasion"}
                );
            context.Products.AddRange(
                new Product { Title = "LapTop", Description = "Dell Latitude E7470", categoryId = 1, Price = 1000 },
                new Product { Title = "Apple AirPods", Description = "Personalized Spatial Audio", categoryId = 1, Price = 119 },
                new Product { Title = "Kindle", Description = "new 7 glare-free display and weeks of battery life", categoryId = 1, Price = 159 },
                new Product { Title = "Apple Watch", Description = "Smartwatch with Jet Black Aluminium Case with Black Sport Band", categoryId = 1, Price = 379 }
                );
            context.Users.AddRange(
                new User { Name = "Sina Zarabi", Username = "SinaZarabi", Password = "123456" }
                );
            context.SaveChanges();
        }
    }
}

