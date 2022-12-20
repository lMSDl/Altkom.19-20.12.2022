using System.Text.Json.Serialization;

namespace Models
{
    public abstract class Entity : ICloneable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public string GUID { get; set; } = Guid.NewGuid().ToString();

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}