using Student_Management_System.Database;
using Student_Management_System.Modules;
using System;
using System.Linq;

namespace Student_Management_System.Services
{
    public class FliterAgeService
    {
        SchoolSystemDBContext _db = new();

        // Filter students by age using numeric comparisons
        public void FilterByAge()
        {
            Console.WriteLine("Choose filter type: 1=Equal, 2=Greater than, 3=Less than, 4=Range");
            Console.Write("Option: ");
            string option = Console.ReadLine();

            IQueryable<Student> query = _db.Students;

            if (option == "1")
            {
                Console.Write("Enter age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Invalid age");
                    return;
                }

                query = query.Where(s => s.Age == age);
            }
            else if (option == "2")
            {
                Console.Write("Enter minimum age (exclusive): ");
                if (!int.TryParse(Console.ReadLine(), out int min))
                {
                    Console.WriteLine("Invalid age");
                    return;
                }

                query = query.Where(s => s.Age > min);
            }
            else if (option == "3")
            {
                Console.Write("Enter maximum age (exclusive): ");
                if (!int.TryParse(Console.ReadLine(), out int max))
                {
                    Console.WriteLine("Invalid age");
                    return;
                }

                query = query.Where(s => s.Age < max);
            }
            else if (option == "4")
            {
                Console.Write("Enter minimum age: ");
                if (!int.TryParse(Console.ReadLine(), out int min))
                {
                    Console.WriteLine("Invalid minimum age");
                    return;
                }

                Console.Write("Enter maximum age: ");
                if (!int.TryParse(Console.ReadLine(), out int max))
                {
                    Console.WriteLine("Invalid maximum age");
                    return;
                }

                if (min > max)
                {
                    Console.WriteLine("Minimum cannot be greater than maximum");
                    return;
                }

                query = query.Where(s => s.Age >= min && s.Age <= max);
            }
            else
            {
                Console.WriteLine("Unknown option");
                return;
            }

            var students = query.ToList();

            if (!students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.Name} (Age: {student.Age})");
            }
        }
    }
}
