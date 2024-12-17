using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication2.DataAccessLayer;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MyController : Controller
    {
        private readonly AppDbContext _context;
        public MyController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Teacher.Where(x => x.Id == 1).ToList();

            Teacher teacher = new Teacher();
            teacher.Name = "djhcd";
            teacher.Type = "fct";
            teacher.Description = "dhbc";


            _context.Teacher.Add(teacher);

            _context.SaveChanges();



            return Ok("Done Insert");
        }

        public IActionResult Update()
        {
            var data = _context.Teacher.Where(x => x.Id == 2).ToList();


            data[0].Name = "123455789";

            _context.Teacher.Update(data[0]);
            _context.SaveChanges();

            _context.Teacher.Remove(data[0]);

            _context.SaveChanges();

            return Ok(data[0]);
        }
    }
}
