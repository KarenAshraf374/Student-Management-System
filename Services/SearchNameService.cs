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
    public class SearchNameService
    {
        SchoolSystemDBContext _db = new();

        // Search students by name using LINQ Where + Contains
        public void SearchByName()
        {
            Console.Write("Search Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please provide a search term.");
                return;
            }

            var students = _db.Students
                .Where(s => s.Name.Contains(name))
                .ToList();

            if (!students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.Name}");
            }
        }
    }
}
