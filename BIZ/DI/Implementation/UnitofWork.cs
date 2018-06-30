using System;
using System.Collections.Generic;
using System.Text;
using BIZ.DI.Interfaces;
using DTO.Models.School;
using DTO.Data;
namespace BIZ.DI.Implementation
{
    public class UnitofWork : IUnitofWork
    {
        private ApplicationDbContext _applicationDbContext;
        private CourseRepository _courseRepository;
        private StudentRepository _studentRepository;
        public UnitofWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public ICourseRepository<Course> CourseRepository
        {
            get
            {
                return _courseRepository = new CourseRepository(_applicationDbContext);
            }
        }

        public IStudentRepository<Student> StudentRepository
        {
            get
            {
                return _studentRepository = new StudentRepository(_applicationDbContext);
            }
        }





        //public ICourseRepository<Course> _courseRepository => (_courseRepository ?? new CourseRepository(applicationDbContext));

        //public IStudentRepository<Student> _studentRepository => (_studentRepository ?? new StudentRepository(applicationDbContext));



        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
