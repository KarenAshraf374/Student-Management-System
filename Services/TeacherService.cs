using Student_Management_System.Database;
using Student_Management_System.Modules;
using System;
using System.Linq;

namespace Student_Management_System.Services
{
    public class TeacherService
    {
        SchoolSystemDBContext _db = new();

        // Add Teacher
        public void AddTeacher()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age");
                return;
            }

            Console.Write("Email: ");
            string email = Console.ReadLine();

            var teacher = new Teacher
            {
                Name = name,
                Age = age,
                Email = email
            };

            _db.Teachers.Add(teacher);
            _db.SaveChanges();

            Console.WriteLine("Teacher added");
        }

        // Update Teacher
        public void UpdateTeacher()
        {
            Console.Write("Teacher Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id");
                return;
            }

            var teacher = _db.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found");
                return;
            }

            Console.Write("New Name: ");
            teacher.Name = Console.ReadLine();

            Console.Write("New Age: ");
            if (int.TryParse(Console.ReadLine(), out int newAge)) teacher.Age = newAge;

            Console.Write("New Email: ");
            teacher.Email = Console.ReadLine();

            _db.SaveChanges();
            Console.WriteLine("Teacher updated");
        }

        // Delete Teacher
        public void DeleteTeacher()
        {
            Console.Write("Teacher Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id");
                return;
            }

            var teacher = _db.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found");
                return;
            }

            _db.Teachers.Remove(teacher);
            _db.SaveChanges();
            Console.WriteLine("Teacher deleted");
        }

        // Get All Teachers
        public void GetAllTeachers()
        {
            var teachers = _db.Teachers.ToList();
            foreach (var t in teachers)
            {
                Console.WriteLine($"{t.Id} - {t.Name} (Age: {t.Age})");
            }
        }
    }
}
