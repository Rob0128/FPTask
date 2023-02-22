using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FPTask.Repositories;
using FPTask.Models;
using System.Collections.Generic;
using System.Text.Json;


namespace FPTask.Functions
{
    public static class SearchEmployeeById
    {
        [FunctionName("GetEmployeeById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            if (req == null)
            {
                return new NoContentResult();
            };

            var query = req.Query;

            if (!req.Query.ContainsKey("id"))
            {
                return new NoContentResult();
            }

            EmployeeRepository employeeRepository = new EmployeeRepository();
            Employee employee = employeeRepository.GetEmployeeById(Guid.Parse(req.Query["id"]));
            var employeeSerialized = JsonSerializer.Serialize(employee);

            return new OkObjectResult(employeeSerialized);

        }
    }
}
