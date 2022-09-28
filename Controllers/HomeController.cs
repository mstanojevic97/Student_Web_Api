using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Web_Api.Infrastructure;
using Student_Web_Api.Models.Domain;
using Student_Web_Api.Models.ViewModels;
using Student_Web_Api.Service;
using System.Diagnostics;

namespace Student_Web_Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly IHomeService _homeService;

        public HomeController(DataContext context, IHomeService homeService)
        {
            _context = context;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            var studentMarkList = _homeService.GetStudentMarks();
            ViewBag.Courses = _context.Courses.ToList();
            return View(studentMarkList);
        }

        public IActionResult GetTablePartial(string student = "", string course = "")
        {
            var studentMarkList = _homeService.GetStudentMarks(student, course);
            if(string.IsNullOrEmpty(course))
            {
                ViewBag.Courses = _context.Courses.ToList();
            }
            else
            {
                ViewBag.Courses = _context.Courses.Where(x => x.Name.ToLower().Contains(course.ToLower()) ||
                                                              x.Code.ToString().ToLower().Contains(course.ToLower())).ToList();
            }
            return PartialView("Table", studentMarkList);
        }

        public IActionResult Courses()
        {
            List<Course> courses = _context.Courses.ToList();
            return View(courses);
        }
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            var cou = new Course()
            {
                Code = course.Code,
                Name = course.Name,
                Description = course.Description
            };
            _context.Courses.Add(cou);
            _context.SaveChanges();
            return Json(true);
        }
        public IActionResult DeleteCourse(int Id)
        {
            Course course = _context.Courses.Find(Id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("Courses");
        }
        public IActionResult EditCourse(int id)
        {
            Course course = _context.Courses.Find(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            _context.Update(course);
            _context.SaveChanges();
            return RedirectToAction("Courses");
        }
        public IActionResult Students()
        {
            List<Student> students = _context.Students.ToList();
            return View(students);
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var stu = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address = student.Address,
                City = student.City,
                State = student.State,
                DateBirth = student.DateBirth,
                Sex = student.Sex
            };
            _context.Students.Add(stu);
            _context.SaveChanges();
            return Json(true);
        }
        public IActionResult DeleteStudent(int Id)
        {
            Student student = _context.Students.Find(Id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Students");
        }
        public IActionResult EditStudent(int id)
        {
            Student student = _context.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Students");
        }
    }
}