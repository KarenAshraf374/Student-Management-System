using Student_Management_System.Modules;
using System;

namespace Student_Management_System.Modules
{
    public class Teacher : BaseModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
    }
}
