using System.Text.Json;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using TicketHub.Models;

namespace TicketHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly IConfiguration _configuration;

        public PurchaseController(ILogger<PurchaseController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public async Task<IActionResult> Post()
        //public async Task<IActionResult> Post(CustomerPurchase purchase)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            string queueName = "purchase";
            string? connectionString = _configuration["AzureConnectionString"];

            if (String.IsNullOrEmpty(connectionString))
            {
                return BadRequest("Bad Connection String");
            }

            QueueClient qc = new QueueClient(connectionString, queueName);

            //string message = JsonSerializer.Serialize(purchase);
            string message = "TESTING FROM API!";


            await qc.SendMessageAsync(message);


            return Ok("Hello, you added this message to the queue! " + message);
        }
    }
}
