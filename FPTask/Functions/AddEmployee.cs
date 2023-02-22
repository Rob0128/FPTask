using FPTask.Models;
using FPTask.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;


namespace FPTask.Functions
{
    public static class AddEmployee
    {
        [FunctionName("AddEmployee")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            if (req == null)
            {
                return new NoContentResult();
            };

            var query = req.Query;

            if (!req.Query.ContainsKey("id") || !req.Query.ContainsKey("firstName") || !req.Query.ContainsKey("surname") || !req.Query.ContainsKey("email") || !req.Query.ContainsKey("startDate") || !req.Query.ContainsKey("endDate") || !req.Query.ContainsKey("jobTitle"))
            {
                return new NoContentResult();
            }
            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository();
                Employee employee = new Employee();
                employee.Id = Guid.Parse(req.Query["id"]);
                employee.FirstName = req.Query["firstName"];
                employee.Surname = req.Query["surname"];
                employee.Email = req.Query["email"];
                employee.StartDate = DateOnly.Parse(req.Query["startDate"]);
                employee.EndDate = DateOnly.Parse(req.Query["endDate"]);
                employee.JobTitle = req.Query["jobTitle"];
                if (req.Query.ContainsKey("profileImage"))
                {
                    employee.ProfileImage = req.Query["profileImage"];
                }
            }
            catch (Exception e)
            {
                
            }
            

            return new OkObjectResult("Successfully added employee");

        }
    }
}
