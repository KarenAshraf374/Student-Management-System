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
    public class StudentService
    {
         SchoolSystemDBContext _db = new();

        //Add Method
        public void AddStudent()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Student student = new Student()
            {
                Name = name,
                Age = age,
                Email = email
            };

            _db.Students.Add(student);   // Stage in memory
            _db.SaveChanges();          // Execute SQL INSERT

            Console.WriteLine("Student Added Successfully");
        }

        //Update Method
        public void UpdateStudent()
        {
            Console.Write("Student Id: ");
            int id = int.Parse(Console.ReadLine());

            var student = _db.Students
                .FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                Console.Write("New Name: ");
                student.Name = Console.ReadLine();

                _db.SaveChanges();  // Executes UPDATE

                Console.WriteLine("Updated");
            }
        }

        //Delete Method
        public void DeleteStudent()
        {
            Console.Write("Student Id: ");
            int id = int.Parse(Console.ReadLine());

            var student = _db.Students
                .FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                _db.Students.Remove(student);  // Stage for deletion
                _db.SaveChanges();             // Executes DELETE

                Console.WriteLine("Deleted");
            }
        } 

       //Get Method
       public void GetAllStudents()
        {
            var students = _db.Students
                .ToList();

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"{student.Id} - {student.Name}");
            }
        }
    }
}
