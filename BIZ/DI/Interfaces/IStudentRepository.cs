using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Models.School;

namespace BIZ.DI.Interfaces
{
    public interface IStudentRepository<Student>
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
