using MongoDB.Bson.Serialization.Attributes;

namespace WebSCOUTL.Models
{
    public class TimeRegistry
    {
        [BsonElement("time_in")]
        public string TimeIn { get; set; }

        [BsonElement("time_out")]
        public string TimeOut { get; set; }

        public TimeRegistry() { }

        public TimeRegistry(string timeIn, string timeOut)
        {
            TimeIn = timeIn;
            TimeOut = timeOut;
        }
    }
}
