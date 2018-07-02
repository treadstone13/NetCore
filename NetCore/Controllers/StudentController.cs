using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIZ.DI.Interfaces;
using DTO.Models.School;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore.Controllers
{
    
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private IUnitofWork _unitofWork;
        public StudentController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        // GET: api/<controller>
        [HttpGet]
        public JsonResult Get()
        {
            var ListAll = _unitofWork.StudentRepository.GetStudents();
            return Json(ListAll);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_unitofWork.StudentRepository.GetStudent(id));
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]Student student)
        {
            _unitofWork.StudentRepository.AddStudent(student);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Update([FromBody]Student student)
        {
            _unitofWork.StudentRepository.UpdateStudent(student);
        }
        //[HttpPost]
        //public IActionResult Update([FromBody]Student student)
        //{
        //    _unitofWork.StudentRepository.AddStudent(student);
        //    return Ok();
        //}



        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitofWork.StudentRepository.DeleteStudent(id);
        }
    }
}
