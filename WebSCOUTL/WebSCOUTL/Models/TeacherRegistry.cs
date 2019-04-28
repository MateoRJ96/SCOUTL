using MongoDB.Bson.Serialization.Attributes;

namespace WebSCOUTL.Models
{
    public class TeacherRegistry
    {
        [BsonElement("teacher_id")]
        public int TeacherId { get; set; }

        [BsonElement("teacher_fullname")]
        public string TeacherFullName { get; set; }

        [BsonElement("teacher_email")]
        public string TeacherEmail { get; set; }

        [BsonElement("career_registry")]
        public CareerRegistry CareerRegistry { get; set; }

        [BsonElement("grade_registry")]
        public GradeRegistry GradeRegistry { get; set; }

        public TeacherRegistry() { }

        public TeacherRegistry(int id, string fullName, string email, CareerRegistry career, GradeRegistry grade)
        {
            TeacherId = id;
            TeacherFullName = fullName;
            TeacherEmail = email;
            CareerRegistry = career;
            GradeRegistry = grade;
        }
    }
}
