using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public OrderController(IHttpClientFactory factory)
        {
                this._httpClient = factory.CreateClient();
        }

        //http://localhost:5287/api/product

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var products= await _httpClient.GetStringAsync("http://localhost:5287/api/product");

            return Ok(new 
            {
                Message= "Order Created Successfully..",                
                ProductData= products 
            });
        }
    }
}
