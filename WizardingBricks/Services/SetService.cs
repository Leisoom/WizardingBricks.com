using Microsoft.EntityFrameworkCore;
using WizardingBricks.Models;

namespace WizardingBricks.Services;

public class SetService(AppDbContext Context)
{
    public async Task<Set?> GetSetById(int Id)
    {
        var result = await Context.Sets.FirstOrDefaultAsync(s => s.Id == Id);
        return result;
    }

    public async Task<List<Set>> GetSetList()
    {
        var list = await Context.Sets.ToListAsync();
        return list;
    }

    public async Task AddSet(Set set)
    {
        Context.Sets.Add(set);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateSet(Set set)
    {
        var dbSet = await GetSetById(set.Id);

        if(dbSet is not null)
        {
            dbSet.Set_Number = set.Set_Number;
            dbSet.Number_Of_Parts = set.Number_Of_Parts;
            dbSet.Year = set.Year;
            dbSet.Preview_Image_URL = set.Preview_Image_URL;
            dbSet.Instructions_URL = set.Instructions_URL;
            dbSet.Name = set.Name;

            await Context.SaveChangesAsync();
        }
    }

}

