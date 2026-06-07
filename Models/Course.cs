using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Modules
{
    public class Course : BaseModel
    {
        public string Title { get; set; }
        public int Hours { get; set; }
    }

}
