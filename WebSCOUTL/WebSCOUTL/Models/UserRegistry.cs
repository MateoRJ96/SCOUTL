using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using WebSCOUTL.Enums;

namespace WebSCOUTL.Models
{
    public class UserRegistry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("date_registry")]
        public DateTime DateRegistry { get; set; }

        [BsonElement("lab_evidence_id")]
        public int LabEvidenceId { get; set; }

        [BsonElement("teacher_registry")]
        public TeacherRegistry Teacher { get; set; }

        [BsonElement("time_registry")]
        public TimeRegistry Time { get; set; }

        [BsonElement("activity_registry")]
        public ActivityRegistry Activity { get; set; }

        [BsonElement("location_registry")]
        public LocationRegistry Location { get; set; }

        [BsonElement("lab_registry")]
        public LabRegistry Lab { get; set; }

        [BsonElement("students_number")]
        public int StundentsNumber { get; set; }

        [BsonElement("is_checked")]
        public bool IsChecked { get; set; }

        [BsonElement("counter")]
        public long Counter { get; set; }

        public UserRegistry () { }

        public UserRegistry(Dictionary<ERegistry, object> map) {
            DateRegistry = (DateTime)map[ERegistry.DATE_REGISTRY];
            LabEvidenceId = int.Parse(map[ERegistry.LAB_EVIDENCE_ID].ToString());
            Teacher = (TeacherRegistry)map[ERegistry.TEACHER];
            Time = (TimeRegistry)map[ERegistry.TIME];
            Activity = (ActivityRegistry)map[ERegistry.ACTIVITY];
            Location = (LocationRegistry)map[ERegistry.LOCATION];
            Lab = (LabRegistry)map[ERegistry.LAB];
            StundentsNumber = int.Parse(map[ERegistry.STUDENTS_NUMBER].ToString());
            IsChecked = bool.Parse(map[ERegistry.IS_CHECKED].ToString());
        }
    }
}
