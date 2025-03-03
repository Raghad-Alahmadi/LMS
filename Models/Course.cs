namespace LMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
