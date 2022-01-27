using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLearning.Model.Interfaces;

namespace WebAppLearning.Model
{
    public class Student : IStudent
    {
        public Person Person { get; set; }

        public List<string> Course { get; set; }

        public List<string> Skill { get; set; }

        public Student()
        {

        }

        public Student(Person person, List<string> course = null, List<string> skill = null)
        {
            this.Person = person;
            this.Course = course;
            this.Skill = skill;
        }

        public void setCourse(List<string> course)
        {
            this.Course = course;
        }

        public void setSkill(List<string> skill)
        {
            this.Skill = skill;
        }

        public List<string> GetCourse()
        {
            return this.Course;
        }

        public List<string> GetSkill()
        {
            return this.Skill;
        }

    }
}
