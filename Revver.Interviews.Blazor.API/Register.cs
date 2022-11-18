using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

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
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            //This API is WAAAYYY too Fast, so adding a delay - JR.
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");
            
            response.WriteString("Welcome to the Blazor Website!");

            return response;
        }
    }
}