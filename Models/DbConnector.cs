using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test100.Models
{
    public class DbConnector
    {
        public static Test100Context conn { get; } = new Test100Context();
    }
}
