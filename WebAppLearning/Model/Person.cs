using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLearning.Model.Interfaces;

namespace WebAppLearning.Model
{
    public class Person : IPerson
    {

        private static int ID;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
        {
            ID = 0;
        }

        public Person(string firstName, string lastName)
        {
            this.GetNextID();

            this.FirstName  = firstName;

            this.LastName   = lastName;
        }
        
        //Static constructor to init the static memmber.
        //This is called one time, automaticcaly before any instance
        static Person() => ID = 0;

        protected int GetNextID() => ++ID;

    }
}
