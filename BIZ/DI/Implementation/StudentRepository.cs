using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIZ.DI.Interfaces;
using DTO.Models.School;
using DTO.Data;

namespace BIZ.DI.Implementation
{
    public class StudentRepository : IStudentRepository<Student>
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

        public Student GetStudent(int id)
        {
            var s = ctx.Students.FirstOrDefault(b => b.StudentID == id);
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
                s.PhoneNumber = student.PhoneNumber;
                s.CourseID = student.CourseID;
                ctx.SaveChanges();
            }
           
        }
    }
}
