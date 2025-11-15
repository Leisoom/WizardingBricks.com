namespace WizardingBricks.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Category> Categories { get; set; } = [];
    public ICollection<Minifigure> Minifigures { get; set; } = [];
}
