namespace WizardingBricks.Models
{
    public class Category
    {
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;

        public ICollection<Set> Sets { get; set; } = [];
    }
}
