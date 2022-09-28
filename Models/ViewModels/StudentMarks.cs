using Student_Web_Api.Models.Domain;

namespace Student_Web_Api.Models.ViewModels
{
    public class StudentMarks
    {
        public string FullName { get; set; }
        public List<Marks> Marks { get; set; }
    }
}
