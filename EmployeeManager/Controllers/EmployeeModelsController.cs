using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManager.Models;

namespace EmployeeManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeModelsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/EmployeeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeModel(int id)
        {
            var employeeModel = await _context.Employee.FindAsync(id);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return employeeModel;
        }

        // PUT: api/EmployeeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeModel(int id, EmployeeModel employeeModel)
        {
            if (id != employeeModel.id)
            {
                return BadRequest();
            }

            _context.Entry(employeeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployeeModel(EmployeeModel employeeModel)
        {
            _context.Employee.Add(employeeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeModel), new { id = employeeModel.id }, employeeModel);
        }

        // DELETE: api/EmployeeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeModel(int id)
        {
            var employeeModel = await _context.Employee.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employeeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeModelExists(int id)
        {
            return _context.Employee.Any(e => e.id == id);
        }
    }
}
