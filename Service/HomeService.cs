using Student_Web_Api.Infrastructure;
using Student_Web_Api.Models.Domain;
using Student_Web_Api.Models.ViewModels;

namespace Student_Web_Api.Service
{
    public class HomeService : IHomeService
    {
        private readonly DataContext _context;

        public HomeService(DataContext context)
        {
            _context = context;
        }

        public List<StudentMarks> GetStudentMarks(string studentSearch = "", string courseSearch = "")
        {
            IQueryable<Course> courses;
            if(string.IsNullOrEmpty(courseSearch))
            {
                courses = _context.Courses.AsQueryable();
            }
            else
            {
                courses = _context.Courses.Where(x=>x.Name.ToLower().Contains(courseSearch.ToLower()) ||
                                                    x.Code.ToString().ToLower().Contains(courseSearch.ToLower()))
                .AsQueryable();
            }
            List<Student> students;
            if(string.IsNullOrEmpty(studentSearch))
            {
                students = _context.Students.ToList();
            }
            else
            {
                students = _context.Students.Where(x=>x.FirstName.ToLower().Contains(studentSearch.ToLower()) ||
                                                      x.LastName.ToLower().Contains(studentSearch.ToLower()) ||
                                                      (x.FirstName.ToLower() + " " + x.LastName.ToLower()).Contains(studentSearch.ToLower()) 
                ).ToList();
            }
            var marks = _context.Marks.AsQueryable();

            List<StudentMarks> studentMarkList = new List<StudentMarks>();
            foreach (var student in students)
            {
                var studentMarks = new StudentMarks();
                studentMarks.FullName = student.FirstName + " " + student.LastName;
                var smData = (from m in marks.Where(x => x.StudentID == student.Id)
                              join c in courses
                              on m.CourseId equals c.Id into mc
                              from markCourse in mc.DefaultIfEmpty()
                              select new
                              {
                                  mark = m
                              }).ToList();
                studentMarks.Marks = new List<Marks>();
                foreach (var sm in smData)
                {
                    studentMarks.Marks.Add(sm.mark);
                }
                studentMarkList.Add(studentMarks);
            }

            return studentMarkList;
        }
    }
}
