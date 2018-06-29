using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Models.School
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int TotalTime { get; set; }
        public DateTime StartTime { get; set; }

    }
}
