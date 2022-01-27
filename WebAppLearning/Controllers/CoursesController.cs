using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using WebAppLearning.Model;
using WebAppLearning.Model.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLearning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        protected Repository repo = Repository.SharedRepository();
        protected SqliteDataAccess _db;

        public CoursesController()
        {
            _db = new SqliteDataAccess();
        }

        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<List<Course>> GetAsync()
        {
            List<Course> courses = await Task.Run(() => repo.GetRecords<Course>(_db, "courses"));
            
            return courses.ToList();
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public Course Get(int id)
        {
            Course course = repo.GetRecordById<Course>(_db, "courses", id);

            return course;
        }

        // POST api/<CoursesController>
        [HttpPost]
        public IActionResult Post([FromForm] Course course)
        {

            string msg = repo.InsertRecord<Course>(_db, "courses");

            return CreatedAtAction(msg, course);

        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string value)
        {
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
