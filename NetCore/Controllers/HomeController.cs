using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCore.DI.Interfaces;
using NetCore.Models;
using NetCore.Models.School;
using X.PagedList;

namespace NetCore.Controllers
{    
    public class HomeController : Controller
    {
        private IStudentRepository _StudentRepository;
        private ICourseRepository _CourseRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IStudentRepository studentRepository, ICourseRepository courseRepository, IHttpContextAccessor httpContextAccessor)
        {
            _StudentRepository = studentRepository;
            _CourseRepository = courseRepository;
            _httpContextAccessor = httpContextAccessor;

        }                

        public IActionResult Index(string sortOrder, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = sortOrder == "id_desc" ? "" : "id_desc";

            var ListAll =  _StudentRepository.GetStudents();
            ViewBag.CourseList = _CourseRepository.GetCourses().Select(c => new SelectListItem { Text = c.Title.ToString(), Value = c.CourseID.ToString() });
            switch (sortOrder)
            {
                case "id_desc":
                    ListAll = ListAll.OrderByDescending(s => s.StudentID);
                    break;
                default:
                    ListAll = ListAll.OrderBy(s => s.StudentID);
                    break;
            }

            var pageNumber = page ?? 1;
            var onePageOfStudent = ListAll.ToPagedList(pageNumber, 5);
            ViewBag.onePageOfStudent = onePageOfStudent;
            return View();
        }


        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _StudentRepository.AddStudent(student);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteStudent(int id)
        {
            _StudentRepository.DeleteStudent(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdateStudent(Student student)
        {
            _StudentRepository.UpdateStudent(student);
            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        
        public IActionResult Course(string sortOrder, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = sortOrder == "id_desc" ? "" : "id_desc";

            var ListAll = _CourseRepository.GetCourses();

            switch (sortOrder)
            {
                case "id_desc":
                    ListAll = ListAll.OrderByDescending(s => s.CourseID);
                    break;
                default:
                    ListAll = ListAll.OrderBy(s => s.CourseID);
                    break;
            }

            var pageNumber = page ?? 1;
            var onePageOfCourse = ListAll.ToPagedList(pageNumber, 5);
            ViewBag.onePageOfCourse = onePageOfCourse;
            return View();
        }
        
        public IActionResult DeleteCourse(int id)
        {
            _CourseRepository.DeleteCourse(id);
            return RedirectToAction("Course", "Home");
        }

        public IActionResult UpdateCourse(Course course)
        {
            _CourseRepository.UpdateCourse(course);
            return RedirectToAction("Course", "Home");
        }

        public IActionResult AddCourse(Course course)
        {
            _CourseRepository.AddCourse(course);
            return RedirectToAction("Course", "Home");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
