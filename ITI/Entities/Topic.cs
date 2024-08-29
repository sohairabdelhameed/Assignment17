using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Entities
{
    public class Topic
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Course> Courses { get; set; }
    }
}
