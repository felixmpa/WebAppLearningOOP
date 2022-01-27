using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WebAppLearning.Model.Abstract
{
    public abstract class DataAccess
    {
        public string DbName;
        public abstract void DbInit();

    }
}
