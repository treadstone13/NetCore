using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.DI.Interfaces;
using NetCore.Models.School;
using NetCore.Data;

namespace NetCore.DI.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationDbContext ctx;
        public StudentRepository(ApplicationDbContext aplicationDbContext)
        {
            this.ctx = aplicationDbContext;
        }
        public void AddStudent(Student student)
        {
            ctx.Students.Add(student);
            ctx.SaveChanges();
            
        }

        public void DeleteStudent(int id)
        {
            var student = ctx.Students.FirstOrDefault(b => b.StudentID == id);
            if (student != null)
            {
                ctx.Students.Remove(student);
                ctx.SaveChanges();
            }
            
        }

        public Student GetStudent(Student student)
        {
            var s = ctx.Students.FirstOrDefault(b => b.StudentID == student.StudentID);
            return s;
          
        }

        public IEnumerable<Student> GetStudents()
        {
            var students = ctx.Students.ToList();
            return students;
         
        }

        public void UpdateStudent(Student student)
        {          
            var s = ctx.Students.Find(student.StudentID);
            if (s != null)
            {
                s.StudentID = student.StudentID;                
                s.FirstName = student.FirstName;
                s.LastName = student.LastName;
                s.Address = student.Address;
                s.CourseID = student.CourseID;
                ctx.SaveChanges();
            }
           
        }
    }
}
