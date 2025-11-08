using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WizardingBricks.Models;

namespace WizardingBricks.Services;

public class CategoryService(AppDbContext Context)
{
    public async Task<Category?> GetCategoryAsync(int id)
    {
        var res = await Context.Categories.FirstOrDefaultAsync(cat => cat.Id == id);
        return res;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await Context.Categories.ToListAsync();
    }

    public async Task AddCategory(Category category)
    {
        Context.Categories.Add(category);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateCategory(Category category)
    {
        var dbCategory = await GetCategoryAsync(category.Id);

        if (dbCategory is not null)
        {
            dbCategory.Name = category.Name;
            dbCategory.Color = category.Color;

            await Context.SaveChangesAsync();
        }
    }
}

