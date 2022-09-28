using Microsoft.EntityFrameworkCore;
using Student_Web_Api.Infrastructure;
using Student_Web_Api.Models.Domain;

namespace Student_Web_Api.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if(!context.Students.Any() && !context.Courses.Any())
            {
                context.Students.AddRange(
                    new Student
                    {
                        FirstName = "Milos",
                        LastName = "Stanojevic",
                        Address = "Vladicin Han",
                        City = "Vladicin Han",
                        State = "Srbija",
                        DateBirth = DateTime.Now,
                        Sex = "Male"
                    },
                    new Student
                    {
                        FirstName = "Lazar",
                        LastName = "Trifunovic",
                        Address = "Prokuplje",
                        City = "Prokuplje",
                        State = "Srbija",
                        DateBirth = DateTime.Now,
                        Sex = "Male"
                    },
                    new Student
                    {
                        FirstName = "Jelena",
                        LastName = "Stojanovic",
                        Address = "Surdulica",
                        City = "Surdulica",
                        State = "Srbija",
                        DateBirth = DateTime.Now,
                        Sex = "Female"
                    },
                    new Student
                    {
                        FirstName = "Danica",
                        LastName = "Peric",
                        Address = "Novi Sad",
                        City = "Novi Sad",
                        State = "Srbija",
                        DateBirth = DateTime.Now,
                        Sex = "Female"
                    }
                    );
                context.Courses.AddRange(
                    new Course
                    {
                        Code = 1111,
                        Name = "JavaScript",
                        Description = "JavaScript fundamentals"
                    },
                    new Course
                    {
                        Code = 1112,
                        Name = ".NET Core",
                        Description = ".NET Core fundamentals"
                    },
                    new Course
                    {
                        Code = 1112,
                        Name = "Python",
                        Description = "Python fundamentals"
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
