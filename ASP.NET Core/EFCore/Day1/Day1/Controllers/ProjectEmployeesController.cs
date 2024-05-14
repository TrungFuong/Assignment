using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day1;
using Day1.Model;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeesController : ControllerBase
    {
        private readonly CompanyDBContext _context;

        public ProjectEmployeesController(CompanyDBContext context)
        {
            _context = context;
        }

        // GET: api/ProjectEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectEmployee>>> GetProjectEmployees()
        {
            return await _context.ProjectEmployees.ToListAsync();
        }

        // GET: api/ProjectEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectEmployee>> GetProjectEmployee(int id)
        {
            var projectEmployee = await _context.ProjectEmployees.FindAsync(id);

            if (projectEmployee == null)
            {
                return NotFound();
            }

            return projectEmployee;
        }

        // PUT: api/ProjectEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectEmployee(int id, ProjectEmployee projectEmployee)
        {
            if (id != projectEmployee.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projectEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectEmployeeExists(id))
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

        // POST: api/ProjectEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectEmployee>> PostProjectEmployee(ProjectEmployee projectEmployee)
        {
            _context.ProjectEmployees.Add(projectEmployee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectEmployeeExists(projectEmployee.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjectEmployee", new { id = projectEmployee.ProjectId }, projectEmployee);
        }

        // DELETE: api/ProjectEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectEmployee(int id)
        {
            var projectEmployee = await _context.ProjectEmployees.FindAsync(id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            _context.ProjectEmployees.Remove(projectEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectEmployeeExists(int id)
        {
            return _context.ProjectEmployees.Any(e => e.ProjectId == id);
        }

        [HttpGet("employee-with-projects")]
        public async Task<ActionResult<IEnumerable<Object>>> GetEmployeesWithProjects()
        {
            var query = @"SELECT 
                            e.Id AS EmployeeId,
                            e.Name AS EmployeeName,
                            e.DepartmentId,
                            p.Id AS ProjectId,
                            p.Name AS ProjectName,
                            pe.Enable
                        FROM Employees e
                        LEFT JOIN ProjectEmployees pe ON e.Id = pe.EmployeeId
                        LEFT JOIN Projects p ON pe.ProjectId = p.Id";
            return await _context.Database.SqlQueryRaw<ProjectEmployeeSQL>(query).ToListAsync();

        }
    }
}
