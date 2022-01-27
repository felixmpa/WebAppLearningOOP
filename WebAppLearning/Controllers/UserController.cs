using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLearning.Model.Abstract;
using WebAppLearning.Model;


namespace WebAppLearning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {

            Person person = new Person("Felix", "Perez");

            List<string> course = new List<string>
            {
                "Scrum",
                "Big Data and Data Science",
                "Degree Computer Science"
            };

            List<string> skill = new List<string>
            {
                "C#", "PHP", "Python"
            };


            Student student = new Student(person, course, skill);




            return Ok();
        }
    }
}
