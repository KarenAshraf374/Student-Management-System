using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Student_Management_System.Database;
using Student_Management_System.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Student_Management_System.Services
{
    public class CourseService
    {
        SchoolSystemDBContext _db = new();

        // Add Method
        public void AddCourse()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Hours: ");
            int hours = int.Parse(Console.ReadLine());

            Course course = new Course()
            {
                Title = title,
                Hours = hours
            };

            _db.Courses.Add(course);
            _db.SaveChanges();

            Console.WriteLine("Course Added Successfully");
        }

        // Update Method
        public void UpdateCourse()
        {
            Console.Write("Course Id: ");
            int id = int.Parse(Console.ReadLine());

            var course = _db.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                Console.Write("New Title: ");
                course.Title = Console.ReadLine();

                Console.Write("New Hours: ");
                course.Hours = int.Parse(Console.ReadLine());

                _db.SaveChanges();

                Console.WriteLine("Updated");
            }
        }

        // Delete Method
        public void DeleteCourse()
        {
            Console.Write("Course Id: ");
            int id = int.Parse(Console.ReadLine());

            var course = _db.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                _db.Courses.Remove(course);
                _db.SaveChanges();

                Console.WriteLine("Deleted");
            }
        }

        // Get Method
        public void GetAllCourses()
        {
            var courses = _db.Courses
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Id} - {course.Title} ({course.Hours} hrs)");
            }
        }
    }
}
