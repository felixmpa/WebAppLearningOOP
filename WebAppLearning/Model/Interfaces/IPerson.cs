using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLearning.Model.Interfaces
{
    public interface IPerson
    {
        static int ID;
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
