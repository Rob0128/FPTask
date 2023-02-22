using Dapper;
using FPTask.Interfaces;
using FPTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.IDbConnection;

namespace FPTask.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public int CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            using IDbConnection rdb = new SqlConnection(AppConnection.ConnectionString);
            if (rdb.State == ConnectionState.Closed)
            {
                rdb.Open();
            }
            return (List<Employee>)rdb.Query<Employee>("SELECT * FROM Employees");
        }

        public Employee GetEmployeeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(Guid EmployeeId, Employee employeeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
