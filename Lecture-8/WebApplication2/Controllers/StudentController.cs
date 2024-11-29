﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DataAcessLayer;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public IActionResult GetStudentRecord()
        //{
        //    var data = _context.StdDetails.ToList();
        //    return Ok(data);

        //}
        [HttpGet("GetStudent")]
        public async Task<IActionResult> GetStudentRecord2()
        {
            var data = await _context.StdDetails.ToListAsync();
            return Ok(data);

        }
        [HttpPost]
        public async Task<IActionResult> InsertStdRecord(Student std)
        {
            await _context.StdDetails.AddAsync(std);
            await _context.SaveChangesAsync();
            return Ok();


        }
        [HttpPut]
        public async Task<IActionResult> UpdateRecord(Student std)
        {
            
            _context.StdDetails.Update(std);
            await _context.SaveChangesAsync();
            return Ok();


        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRecord(Student std)
        {
            
            _context.StdDetails.Remove(std);
            await _context.SaveChangesAsync();
            return Ok();


        }
    }
}
