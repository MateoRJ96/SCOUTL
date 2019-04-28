using MongoDB.Bson.Serialization.Attributes;

namespace WebSCOUTL.Models
{
    public class LocationRegistry
    {
        [BsonElement("location_id")]
        public int LocationId { get; set; }

        [BsonElement("location_name")]
        public string LocationName { get; set; }

        public LocationRegistry() { }

        public LocationRegistry(int id, string name)
        {
            LocationId = id;
            LocationName = name;
        }
    }
}
