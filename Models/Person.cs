namespace Models
{
    //: - dziedziczenie
    public class Person : Entity
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }


        //override - nadpisanie metody bazowej
        public override string ToString()
        {
            //1. Michał Michałowski 21
            //return Id + ".\t" + Name + "\t" + Age;
            //var format = "{2}.\t{0}\t{1}";
            //return string.Format(format, Name, Age, Id);

            //string interpolowany
            return $"{Id}.\t{Name}\t{Age}";
        }
    }
}