using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIZ.DI.Interfaces;
using DTO.Models.School;
using DTO.Data;

namespace BIZ.DI.Implementation
{
    public class CourseRepository : ICourseRepository<Course>
    {
        private ApplicationDbContext ctx;
        public CourseRepository(ApplicationDbContext aplicationDbContext)
        {
            this.ctx = aplicationDbContext;
        }
        public void AddCourse(Course course)
        {
            ctx.Courses.Add(course);
            ctx.SaveChanges();
            
        }

        public void DeleteCourse(int id)
        {
            var course = ctx.Courses.FirstOrDefault(b => b.CourseID == id);
            if (course != null)
            {
                ctx.Courses.Remove(course);
                ctx.SaveChanges();
            }
          
        }

        public Course GetCourse(Course course)
        {
            var c = ctx.Courses.FirstOrDefault(b => b.CourseID == course.CourseID);
            return c;
           
        }

        public IEnumerable<Course> GetCourses()
        {
            var course = ctx.Courses.ToList();
            return course;
           
        }

        public void UpdateCourse(Course course)
        {           
            var c = ctx.Courses.Find(course.CourseID);
            if (c != null)
            {
                c.CourseID = course.CourseID;
                c.Title = course.Title;
                c.TotalTime = course.TotalTime;
                c.StartTime = course.StartTime;
                ctx.SaveChanges();
            }
          
        }
    }
}
