using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace salesdemo
{
    public static class getproduct
    {
        [FunctionName("getproduct")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            Product product = new Product
            {
                Id = "1",
                Name = "Beans",
                Category = "Food",
                Price = "100"
            };

            string productDetail = JsonConvert.SerializeObject(product);

            return await Task.FromResult(new OkObjectResult(productDetail));
        }

        public class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Price { get; set; }
        }   
    }
}
