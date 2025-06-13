using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExpenseTracker.Core.Categories;

namespace ExpenseTracker.Infrastructure.Common.Initializers;

public static class ExpenseTrackerInitializer
{
    public static async Task SeedCategoriesDataAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.EnsureCreatedAsync();

        if (!context.Categories.Any())
        {
            var categories = new List<Category>
            {
                new()
                {
                    Name = "Food",
                    IconPath = "food.png",
                    CategoryItems = new List<CategoryItem>
                    {
                        new() { Name = "Meat" },
                        new() { Name = "Vegetables/Greens" },
                        new() { Name = "Grains" },
                        new() { Name = "Sauces" },
                        new() { Name = "Dairy" },
                        new() { Name = "Bread" },
                        new() { Name = "Sweets" },
                    }
                },
                new()
                {
                    Name = "Entertainment",
                    IconPath = "entertainment.png",
                    CategoryItems = new List<CategoryItem>
                    {
                        new() { Name = "Alcohol" },
                        new() { Name = "Fast Food" },
                        new() { Name = "Cafe" },
                        new() { Name = "Cinema" },
                        new() { Name = "Events" },
                    }
                },
                new()
                {
                    Name = "Personal",
                    // IconPath = "icons/categories/personal.png",
                    CategoryItems = new List<CategoryItem>()
                },
                new()
                {
                    Name = "Pet",
                    // IconPath = "icons/categories/pet.png",
                    CategoryItems = new List<CategoryItem>
                    {
                        new() { Name = "Food" },
                        new() { Name = "Vet" },
                        new() { Name = "Toys" },
                        new() { Name = "Grooming" },
                    }
                },
                new()
                {
                    Name = "Medicine",
                    // IconPath = "icons/categories/medicine.png",
                    CategoryItems = new List<CategoryItem>
                    {
                        new() { Name = "Painkillers" },
                        new() { Name = "Vitamins" },
                        new() { Name = "Antibiotics" },
                    }
                },
                new()
                {
                    Name = "Hygiene",
                    // IconPath = "icons/categories/hygiene.png",
                    CategoryItems = new List<CategoryItem>
                    {
                        new() { Name = "Shampoo" },
                        new() { Name = "Soap" },
                        new() { Name = "Laundry Powder" },
                        new() { Name = "Toothpaste" },
                        new() { Name = "Toilet Paper" },
                    }
                },
                new()
                {
                    Name = "Household",
                    // IconPath = "icons/categories/household.png",
                    CategoryItems = new List<CategoryItem>
                    {
                        new() { Name = "Dish Soap" },
                        new() { Name = "Sponges" },
                        new() { Name = "Tableware" },
                        new() { Name = "Trash Bags" },
                        new() { Name = "Napkins" },
                    }
                },
                new()
                {
                    Name = "Credit Card",
                    // IconPath = "icons/categories/credit-card.png",
                    CategoryItems = new List<CategoryItem>
                    {
                        new() { Name = "Payment" },
                        new() { Name = "Interest" },
                        new() { Name = "Fees" },
                    }
                },
                new()
                {
                    Name = "Utilities",
                    // IconPath = "icons/categories/utilities.png",
                    CategoryItems = new List<CategoryItem>
                    {
                        new() { Name = "Electricity" },
                        new() { Name = "Water" },
                        new() { Name = "Gas" },
                        new() { Name = "Heating" },
                    }
                },
                new()
                {
                    Name = "Communication",
                    // IconPath = "icons/categories/communication.png",
                    CategoryItems = new List<CategoryItem>
                    {
                        new() { Name = "Mobile" },
                        new() { Name = "Internet" },
                        new() { Name = "ChatGPT" },
                        new() { Name = "Subscriptions" },
                    }
                }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
        }
    }
}
