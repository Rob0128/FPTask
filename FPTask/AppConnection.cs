using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FPTask
{
    public static class AppConnection
    {
        public static string ConnectionString = "Server=localhost\\MSSQLSERVER01;Database=master;Trusted_Connection=True;";
    }
}
