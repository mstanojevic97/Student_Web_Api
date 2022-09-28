using Student_Web_Api.Models.ViewModels;

namespace Student_Web_Api.Service
{
    public interface IHomeService
    {
        public List<StudentMarks> GetStudentMarks(string studentSearch = "", string courseSearch = "");
    }
}
