using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Entities
{
    public class Course
    {
        public int ID { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Foreign Key
        public int Top_ID { get; set; }

        // Navigation Properties
        public Topic Topic { get; set; }
        public ICollection<Stud_Course> Stud_Courses { get; set; }
        public ICollection<Course_Inst> Course_Insts { get; set; }
    }
}
