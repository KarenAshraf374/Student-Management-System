using Student_Management_System.Database;
using Student_Management_System.Modules;
using System;
using System.Linq;

namespace Student_Management_System.Services
{
    public class ManagerService
    {
        SchoolSystemDBContext _db = new();

        //add manager
        public void AddManager()
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

            var manager = new Manager { Name = name, Age = age, Email = email };
            _db.Managers.Add(manager);
            _db.SaveChanges();

            Console.WriteLine("Manager added");
        }

        //get all managers
        public void GetAllManagers()
        {
            var managers = _db.Managers.ToList();
            foreach (var m in managers)
            {
                Console.WriteLine($"{m.Id} - {m.Name} (Age: {m.Age})");
            }
        }

        //update manager
        public void UpdateManager()
        {
            Console.Write("Manager Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id");
                return;
            }

            var manager = _db.Managers.FirstOrDefault(m => m.Id == id);
            if (manager == null)
            {
                Console.WriteLine("Manager not found");
                return;
            }

            Console.Write("New Name: ");
            manager.Name = Console.ReadLine();
            Console.Write("New Age: ");
            if (int.TryParse(Console.ReadLine(), out int newAge)) manager.Age = newAge;
            Console.Write("New Email: ");
            manager.Email = Console.ReadLine();

            _db.SaveChanges();
            Console.WriteLine("Manager updated");
        }

        //delete manager
        public void DeleteManager()
        {
            Console.Write("Manager Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id");
                return;
            }

            var manager = _db.Managers.FirstOrDefault(m => m.Id == id);
            if (manager == null)
            {
                Console.WriteLine("Manager not found");
                return;
            }

            _db.Managers.Remove(manager);
            _db.SaveChanges();
            Console.WriteLine("Manager deleted");
        }
    }
}
