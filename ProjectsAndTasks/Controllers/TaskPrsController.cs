using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskPrsController : ControllerBase
    {
        private readonly ProjectContext _context;
         
        public TaskPrsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/TaskPrs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskPr>>> GetTaskItems()
        {
            return await _context.TaskItems.ToListAsync();
        }

        // GET: api/TaskPrs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskPr>> GetTaskPr(int id)
        {
            var taskPr = await _context.TaskItems.FindAsync(id);

            if (taskPr == null)
            {
                return NotFound();
            }

            return taskPr;
        }

        // PUT: api/TaskPrs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskPr(int id, TaskPr taskPr)
        {
            if (id != taskPr.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskPr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskPrExists(id))
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

        // POST: api/TaskPrs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskPr>> PostTaskPr(TaskPr taskPr)
        {
            _context.TaskItems.Add(taskPr);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaskPr), new { id = taskPr.Id }, taskPr);
            //return CreatedAtAction("GetTaskPr", new { id = taskPr.Id }, taskPr);
        }

        // DELETE: api/TaskPrs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskPr>> DeleteTaskPr(int id)
        {
            var taskPr = await _context.TaskItems.FindAsync(id);
            if (taskPr == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(taskPr);
            await _context.SaveChangesAsync();

            return taskPr;
        }

        private bool TaskPrExists(int id)
        {
            return _context.TaskItems.Any(e => e.Id == id);
        }
    }
}
