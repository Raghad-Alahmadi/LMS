namespace LMS.Models
{
    // Models/Student.cs
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public ICollection<Course> EnrolledCourses { get; set; }
    }

}
