// Models/Instructor.cs
namespace LMS.Models
{

    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}