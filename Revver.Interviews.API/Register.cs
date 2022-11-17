using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using Revver.Interviews.API.Services;

namespace Revver.Interviews.API
{
    public class Register
    {
        protected readonly IServiceProvider Services;
        //public Register(IServiceProvider services)
        //{
        //    Services = services;
        //}

        [FunctionName("Register")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger log)
        {

            using var scope = Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var userService = scope.ServiceProvider.GetService<UserService>();


            
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            userService.RegisterAsync(data);


            string responseMessage = string.IsNullOrEmpty(data)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
