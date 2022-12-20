namespace Models
{
    public abstract class Entity : ICloneable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}