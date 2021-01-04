using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolytechExamBase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PolytechExamBase.Controllers
{
    [EnableCors("myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class PassedTaskController : ControllerBase
    {

        private readonly PolytechExamTestContext _context;

        public PassedTaskController(PolytechExamTestContext context)
        {
            _context = context;
        }

        // GET: api/PassedTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassedTask>>> GetPassedTask()
        {
            return await _context.PassedTask.ToListAsync();
        }

        // GET: api/PassedTask/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassedTask>> GetPassedTask(int id)
        {
            var passed_task = await _context.PassedTask.FindAsync(id);

            if (passed_task == null)
            {
                return NotFound();
            }

            return passed_task;
        }

        // PUT: api/PassedTask/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassedTask(int id, PassedTask passed_task)
        {
            //if (id != passed_task.PassedTaskId)
            //{
            //    return BadRequest();
            //}

            passed_task.PassedTaskId = id;

            _context.Entry(passed_task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassedTaskExists(id))
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

        // POST: api/PassedTask
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PassedTask>> PostPassedTask(PassedTask passed_task)
        {
            _context.PassedTask.Add(passed_task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassedTask", new { id = passed_task.PassedTaskId }, passed_task);
        }

        // DELETE: api/PassedTask/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PassedTask>> DeletePassedTask(int id)
        {
            var passed_task = await _context.PassedTask.FindAsync(id);
            if (passed_task == null)
            {
                return NotFound();
            }

            _context.PassedTask.Remove(passed_task);
            await _context.SaveChangesAsync();

            return passed_task;
        }

        private bool PassedTaskExists(int id)
        {
            return _context.PassedTask.Any(e => e.PassedTaskId == id);
        }
    }
}
