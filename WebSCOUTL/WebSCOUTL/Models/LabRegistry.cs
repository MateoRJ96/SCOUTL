using MongoDB.Bson.Serialization.Attributes;

namespace WebSCOUTL.Models
{
    public class LabRegistry
    {
        [BsonElement("lab_name")]
        public string LabName { get; set; }

        [BsonElement("lab_description")]
        public string LabDescription { get; set; }

        public LabRegistry() { }

        public LabRegistry(string name, string description)
        {
            LabName = name;
            LabDescription = description;
        }
    }
}
