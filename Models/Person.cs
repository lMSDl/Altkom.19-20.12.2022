namespace Models
{
    //: - dziedziczenie
    public class Person : Entity
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }


        public string Info => ToString();

        //Newtonsoft.Json pozwala na warunkowe serializowanie wskazanej właściwości
        //ShouldSerialize<nazwa property>
        public bool ShouldSerializeInfo()
        {
            return Name?.Contains("Ewa") ?? false;
        }


        //override - nadpisanie metody bazowej
        public override string ToString()
        {
            //1. Michał Michałowski 21
            //return Id + ".\t" + Name + "\t" + Age;
            //var format = "{2}.\t{0}\t{1}";
            //return string.Format(format, Name, Age, Id);

            //string interpolowany
            //return $"{Id}.\t{Name}\t{Age}";


            //return string.Format("{2,-3}{0,-25}{1,-3}", Name, Age, Id);
            return $"{Id,-3}{Name,-25}{Age,-3}";
        }
    }
}