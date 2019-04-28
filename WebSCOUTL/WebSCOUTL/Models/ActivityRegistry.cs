using MongoDB.Bson.Serialization.Attributes;

namespace WebSCOUTL.Models
{
    public class ActivityRegistry
    {
        [BsonElement("activity_id")]
        public int ActivityId { get; set; }

        [BsonElement("activity_name")]
        public string ActivityName { get; set; }

        public ActivityRegistry() { }

        public ActivityRegistry(int id, string name)
        {
            ActivityId = id;
            ActivityName = name;
        }
    }
}
