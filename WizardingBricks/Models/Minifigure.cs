namespace WizardingBricks.Models;

public class Minifigure
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Number_Of_Parts { get; set; }
    public string Preview_Image_URL { get; set; } = null!;

    public Character? Character { get; set; }
    public ICollection<Set> Sets { get; set; } = [];
}

