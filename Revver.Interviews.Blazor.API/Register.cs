using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Revver.Interviews.Blazor.API
{
    public class Register
    {
        private readonly ILogger _logger;

        public Register(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Register>();
        }

        [Function("Register")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");
            var message = JsonConvert.SerializeObject("Welcome to the Blazor Website!");
            response.WriteString(message);

            return response;
        }
    }
}