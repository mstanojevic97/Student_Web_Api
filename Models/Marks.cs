namespace Student_Web_Api.Models
{
    public class Marks
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentID { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public int Mark { get; set; }
    }
}
