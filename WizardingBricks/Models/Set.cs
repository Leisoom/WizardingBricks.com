namespace WizardingBricks.Models;
public class Set
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Year { get; set; }
    public int Number_Of_Parts { get; set; }

    public int SeriesId { get; set; }
    public Series Series { get; set; } = null!;

}

