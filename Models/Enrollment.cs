using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Modules
{
    public class Enrollment : BaseModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }

}
