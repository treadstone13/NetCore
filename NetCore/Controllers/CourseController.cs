using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIZ.DI.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private IUnitofWork _unitofWork;
        public CourseController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        // GET: api/<controller>
        [HttpGet]
        public JsonResult Get()
        {
            var ListAll = _unitofWork.CourseRepository.GetCourses();
            return Json(ListAll);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
