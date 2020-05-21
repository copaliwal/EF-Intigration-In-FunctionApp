using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionAppEF.EntityFramework.EntityFramework;
using FunctionAppEF.EntityFramework;

namespace FunctionAppEF
{
    public class Function1
    {
        private IOrganizationRepository repo { get; }

        public Function1(IOrganizationRepository _repo)
        {
            repo = _repo;
        }


        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string responseMessage = "No Response";

            try
            { 
                responseMessage = await repo.GetOrganisationConnection();
            }
            catch(Exception ex)
            {
                responseMessage = ex.Message;
            }

            return new OkObjectResult(responseMessage);
        }
    }
}
