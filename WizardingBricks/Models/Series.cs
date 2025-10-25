namespace WizardingBricks.Models;

public class Series
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ICollection<Set> Sets { get; set; } = [];
}

