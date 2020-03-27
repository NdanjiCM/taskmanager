namespace MyTasksManager.Models
{
    public class Category
    {
        public int CategoryId { get; private set; }

        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}
