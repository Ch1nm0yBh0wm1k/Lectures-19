using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.DataAccess;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ValuesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.product.ToList();
            return Ok(data);

        }
        [HttpPost]
        public IActionResult Post(Product pd)
        {
            _context.product.Add(pd);
            _context.SaveChanges(); 



            return Ok(pd);

        }


        [HttpPost("Succesful")]
        public IActionResult Post2(string name)
        {
            

         
            return Ok(name);

        }
    }
}
