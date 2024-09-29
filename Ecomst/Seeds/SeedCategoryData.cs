using Ecomst.Data;
using Ecomst.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecomst.Seeds
{
    public class SeedCategoryData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any categories.
                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Action",
                        DisplayOrder = 1,
                    },
                    new Category
                    {
                        Name = "SciFi",
                        DisplayOrder = 2,
                    },
                    new Category
                    {
                        Name = "History",
                        DisplayOrder = 3,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
