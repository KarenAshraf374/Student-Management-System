using Student_Management_System.Database;
using Student_Management_System.Modules;
using System;
using System.Linq;

namespace Student_Management_System.Services
{
    public class EnrollmentService
    {
        SchoolSystemDBContext _db = new();

        // Create an enrollment linking a student to a course
        public void EnrollStudent()
        {
            Console.Write("Student Id: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid student id");
                return;
            }

            var student = _db.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found");
                return;
            }

            Console.Write("Course Id: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("Invalid course id");
                return;
            }

            var course = _db.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found");
                return;
            }

            // Optionally check for existing enrollment
            var existing = _db.Enrollments.FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);
            if (existing != null)
            {
                Console.WriteLine("Student is already enrolled in this course");
                return;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };

            _db.Enrollments.Add(enrollment);
            _db.SaveChanges();

            Console.WriteLine("Enrollment created");
        }

        // List enrollments with student and course info
        public void GetAllEnrollments()
        {
            var enrollments = _db.Enrollments
                .ToList();

            foreach (var e in enrollments)
            {
                var student = _db.Students.FirstOrDefault(s => s.Id == e.StudentId);
                var course = _db.Courses.FirstOrDefault(c => c.Id == e.CourseId);

                string studentName = student != null ? student.Name : "Unknown Student";
                string courseTitle = course != null ? course.Title : "Unknown Course";

                Console.WriteLine($"{e.Id} - {studentName} -> {courseTitle}");
            }
        }

        // Delete an enrollment by id
        public void DeleteEnrollment()
        {
            Console.Write("Enrollment Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id");
                return;
            }

            var enrollment = _db.Enrollments.FirstOrDefault(e => e.Id == id);
            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found");
                return;
            }

            _db.Enrollments.Remove(enrollment);
            _db.SaveChanges();

            Console.WriteLine("Enrollment deleted");
        }
    }
}
