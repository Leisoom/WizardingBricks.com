using Microsoft.EntityFrameworkCore;
using WizardingBricks.Models;

namespace WizardingBricks.Services;

public class MinifigureService(AppDbContext Context)
{
    public async Task<Minifigure?> GetMinifigureAsync(int id)
    {
        var result = await Context.Minifigures
            .Include(x => x.Character)
            .Include(x => x.Sets)
            .FirstOrDefaultAsync(mf => mf.Id == id);
        return result;
    }
    public async Task<List<Minifigure>> GetMinifiguresAsync()
    {
        return await Context.Minifigures.ToListAsync();
    }

    public async Task AddMinifigure(Minifigure minifigure)
    {
        Context.Minifigures.Add(minifigure);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateMinifigure(Minifigure minifigure)
    {
        var dbMinifigure = await Context.Minifigures.FirstOrDefaultAsync(mf => mf.Id == minifigure.Id);
        if (dbMinifigure != null)
        {
            dbMinifigure.Name = minifigure.Name;
            dbMinifigure.Description = minifigure.Description;
            dbMinifigure.Character = minifigure.Character;
            dbMinifigure.Sets = minifigure.Sets;

            await Context.SaveChangesAsync();
        }
    }

    public async Task DeleteMinifigure(Minifigure minifigure)
    {
        Context.Minifigures.Remove(minifigure);
        await Context.SaveChangesAsync();
    }
}

