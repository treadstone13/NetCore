using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Models.School
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }        
        public string PhoneNumber { get; set; }
        public int CourseID { get; set; }
        public virtual  Course Course { get; set; }

    }
}
