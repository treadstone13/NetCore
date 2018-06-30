using System;
using System.Collections.Generic;
using System.Text;
using DTO.Models.School;

namespace BIZ.DI.Interfaces
{
    public interface IUnitofWork
    {
        ICourseRepository<Course> CourseRepository { get; }
        IStudentRepository<Student> StudentRepository { get; }
        void Save();
    }
}
