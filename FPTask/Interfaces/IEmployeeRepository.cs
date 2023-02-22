using FPTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTask.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();

        Employee GetEmployeeById(Guid id);

        int CreateEmployee(Employee employee);

        int UpdateEmployee(Guid EmployeeId, Employee employeeUpdate);
    }
}
