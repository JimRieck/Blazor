using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Revver.Interviews.Blazor.API
{
    public class ConvertRomanNumeral
    {
        private readonly ILogger _logger;

        public ConvertRomanNumeral(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ConvertRomanNumeral>();
        }

        [Function("ConvertRomanNumeral")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            // use Json.NET to deserialize the posted JSON into a C# dynamic object
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json;");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
