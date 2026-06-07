using Student_Management_System.Database;
using Student_Management_System.Modules;
using System;
using System.Linq;

namespace Student_Management_System.Services
{
    public class ShowStudentCourseService
    {
        SchoolSystemDBContext _db = new();

        // Show all students and the courses they are enrolled in
        public void ShowStudentCourses()
        {
            var students = _db.Students.ToList();
            var enrollments = _db.Enrollments.ToList();
            var courses = _db.Courses.ToList();

            foreach (var student in students)
            {
                var studentEnrollments = enrollments
                    .Where(e => e.StudentId == student.Id)
                    .ToList();

                if (!studentEnrollments.Any())
                {
                    Console.WriteLine($"{student.Id} - {student.Name}: (no courses)");
                    continue;
                }

                var courseTitles = studentEnrollments
                    .Select(e => courses.FirstOrDefault(c => c.Id == e.CourseId)?.Title ?? "Unknown Course")
                    .ToList();

                Console.WriteLine($"{student.Id} - {student.Name}: {string.Join(", ", courseTitles)}");
            }
        }
    }
}
