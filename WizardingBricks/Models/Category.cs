namespace WizardingBricks.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;

        public ICollection<Set> Sets { get; set; } = [];
    }
}
