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

}

