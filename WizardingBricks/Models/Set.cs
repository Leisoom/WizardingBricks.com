namespace WizardingBricks.Models;
public class Set
{
    public int Id { get; set; }
    public string Set_Number { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Year { get; set; }
    public int Number_Of_Parts { get; set; }
    public string? Preview_URL { get; set; } 
}