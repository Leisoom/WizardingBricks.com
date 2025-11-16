using Microsoft.EntityFrameworkCore;
using WizardingBricks.Models;

namespace WizardingBricks.Services;

public class CharacterService(AppDbContext Context)
{
    public async Task<Character?> GetCharacterAsync(int id)
    {
        var result = await Context.Characters
            .Include(c => c.Minifigures)
            .Include(c => c.Categories)
            .FirstOrDefaultAsync(c => c.Id == id);
        return result;
    }
    public async Task<List<Character>> GetCharactersAsync()
    {
        return await Context.Characters.Include(c => c.Minifigures).ToListAsync();
    }

    public async Task AddCharacter(Character character)
    {
        Context.Characters.Add(character);
        await Context.SaveChangesAsync(); 
    }

    public async Task UpdateCharacter(Character character)
    {
        var dbCharacter = await Context.Characters.FirstOrDefaultAsync(c => c.Id == character.Id);
        if (dbCharacter != null)
        {
            dbCharacter.Name = character.Name;
            dbCharacter.Minifigures = character.Minifigures;
            dbCharacter.Categories = character.Categories;

            await Context.SaveChangesAsync();
        }
    }

    public async Task DeleteCharacter(Character character)
    {
        Context.Characters.Remove(character);
        await Context.SaveChangesAsync();
    }
}

