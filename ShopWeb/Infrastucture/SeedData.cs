using Microsoft.EntityFrameworkCore;
using ShopWeb.Models;

namespace ShopWeb.Infrastucture
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if(context.Products.Count() == 0 && context.Categories.Count() == 0)
            {
                Category fruits = new Category() { name = "Fruits" };
                Category shirts = new Category() { name = "shirts" };

                context.Products.AddRange(
                    new Product
                    {
                        name = "Apples",
                        price = 1.50M,
                        Category = fruits
                    },
                    new Product
                    {
                        name = "Lemons",
                        price = 2M,
                        Category = fruits
                    },
                    new Product
                    {
                        name = "Watermelon",
                        price = 0.50M,
                        Category = fruits
                    },
                    new Product
                    {
                        name = "Grapefruit",
                        price = 2.50M,
                        Category = fruits
                    },
                    new Product
                    {
                        name = "Blue shirt",
                        price = 5.99M,
                        Category = shirts
                    },
                    new Product
                    {
                        name = "Black shirt",
                        price = 7.99M,
                        Category = shirts
                    },
                    new Product
                    {
                        name = "Red shirt",
                        price = 9.99M,
                        Category = shirts
                    },
                    new Product
                    {
                        name = "Yellow shirt",
                        price = 11.99M,
                        Category = shirts
                    }
                );
                context.SaveChanges();

            }
        }
    }
}
