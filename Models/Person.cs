namespace Models
{
    //: - dziedziczenie
    public class Person : Entity
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

    }
}