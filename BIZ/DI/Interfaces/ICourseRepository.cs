using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Models.School;

namespace BIZ.DI.Interfaces
{
    public interface ICourseRepository<Course>
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(Course course);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }

}
