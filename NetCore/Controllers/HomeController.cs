using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BIZ.DI.Interfaces;
using DTO.Models;
using DTO.Models.School;
using X.PagedList;
using BIZ.DI.Implementation;

namespace NetCore.Controllers
{    
    public class HomeController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IUnitofWork unitofWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _httpContextAccessor = httpContextAccessor;

        }                

        public IActionResult Index(string sortOrder, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = sortOrder == "id_desc" ? "" : "id_desc";

            var ListAll =  _unitofWork.StudentRepository.GetStudents();
            ViewBag.CourseList = _unitofWork.CourseRepository.GetCourses().Select(c => new SelectListItem { Text = c.Title.ToString(), Value = c.CourseID.ToString() });
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
            _unitofWork.StudentRepository.AddStudent(student);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteStudent(int id)
        {
            _unitofWork.StudentRepository.DeleteStudent(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdateStudent(Student student)
        {
            _unitofWork.StudentRepository.UpdateStudent(student);
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

            var ListAll = _unitofWork.CourseRepository.GetCourses();

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
            _unitofWork.CourseRepository.DeleteCourse(id);
            return RedirectToAction("Course", "Home");
        }

        public IActionResult UpdateCourse(Course course)
        {
            _unitofWork.CourseRepository.UpdateCourse(course);
            return RedirectToAction("Course", "Home");
        }

        public IActionResult AddCourse(Course course)
        {
            _unitofWork.CourseRepository.AddCourse(course);
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
