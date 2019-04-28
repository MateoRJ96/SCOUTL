using MongoDB.Bson.Serialization.Attributes;

namespace WebSCOUTL.Models
{
    public class GradeRegistry
    {
        [BsonElement("grade_id")]
        public int GradeId { get; set; }

        [BsonElement("grade_name")]
        public string GradeName { get; set; }

        public GradeRegistry() { }

        public GradeRegistry(int id, string name)
        {
            GradeId = id;
            GradeName = name;
        }
    }
}
