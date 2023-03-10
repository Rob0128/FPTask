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
    public static class SearchAllEmployees
    {
        [FunctionName("SearchAllEmployees")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            EmployeeRepository employeeRepository = new EmployeeRepository();
            List<Employee> allEmployees = await employeeRepository.GetAllEmployees();
            var allEmployeesSerialized = JsonSerializer.Serialize(allEmployees);

            return new OkObjectResult(allEmployeesSerialized);

        }
    }
}
