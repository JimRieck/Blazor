using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Revver.Interviews.BlazorSite.Services;

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

            using var reader = new StreamReader(req.Body);
            string requestBody = await reader.ReadToEndAsync();

            // use Json.NET to deserialize the posted JSON into a C# dynamic object
            RomanNumeral romanNumeral = JsonConvert.DeserializeObject<RomanNumeral>(requestBody);
            var response = req.CreateResponse(HttpStatusCode.OK);
            
            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
