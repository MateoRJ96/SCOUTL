using MongoDB.Bson.Serialization.Attributes;

namespace WebSCOUTL.Models
{
    public class CareerRegistry
    {
        [BsonElement("career_id")]
        public int CareerId { get; set; }

        [BsonElement("career_name")]
        public string CareerName { get; set; }

        public CareerRegistry() { }

        public CareerRegistry(int id, string name)
        {
            CareerId = id;
            CareerName = name;
        }
    }
}
