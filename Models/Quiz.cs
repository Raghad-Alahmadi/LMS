namespace LMS.Models
{
    // Models/Quiz.cs
    public class Quiz
    {
        public int QuizId { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
