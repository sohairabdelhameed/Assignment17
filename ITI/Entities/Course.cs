using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Entities
{
    internal class Course
    {
        public int ID { get; set; }
        public string? Duration { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Top_ID { get; set; }
    }
}
