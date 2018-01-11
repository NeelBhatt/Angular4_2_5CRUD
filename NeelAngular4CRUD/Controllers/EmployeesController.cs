using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeelAngular4CRUD.Models;

namespace NeelAngular4CRUD.Controllers
{
    [Produces("application/json")]
    [Route("api/Employees")]
    public class EmployeesController : Controller
    {
        private readonly AngularCRUDTestContext _context;

        public EmployeesController(AngularCRUDTestContext context)
        {
            _context = context;
        }
     
        [Route("~/api/GetAllEmployees")]
        [HttpGet]
        public IEnumerable<Employees> GetEmployees()
        {
            return _context.Employees;
        }
       
        [Route("~/api/GetEmployee")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployees([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employees = await _context.Employees.SingleOrDefaultAsync(m => m.StudentId == id);

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }
           
        [Route("~/api/UpdateEmployee")]
        public async Task<IActionResult> PutEmployees([FromBody] Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }          

            _context.Entry(employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return NoContent();
        }
            
        [Route("~/api/AddEmployee")]
        [HttpPost]
        public async Task<IActionResult> PostEmployees([FromBody] Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees.Add(employees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployees", new { id = employees.StudentId }, employees);
        }
       
        [Route("~/api/DeleteEmployee/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employees = await _context.Employees.SingleOrDefaultAsync(m => m.StudentId == id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();

            return Ok(employees);
        }

        private bool EmployeesExists(long id)
        {
            return _context.Employees.Any(e => e.StudentId == id);
        }
    }
}