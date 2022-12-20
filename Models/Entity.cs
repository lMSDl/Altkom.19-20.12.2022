
namespace Models
{
    public abstract class Entity : ICloneable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public string GUID { get; set; } = Guid.NewGuid().ToString();

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}