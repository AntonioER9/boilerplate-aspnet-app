
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }
    }
}