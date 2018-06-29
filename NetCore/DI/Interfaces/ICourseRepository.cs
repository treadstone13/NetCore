using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Models.School;

namespace NetCore.DI.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(Course course);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }

}
