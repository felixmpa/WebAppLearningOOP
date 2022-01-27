using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLearning.Model.Interfaces
{
    public interface IStudent 
    {
        List<string> Course { get; }

        List<string> Skill { get; }
    }
}
