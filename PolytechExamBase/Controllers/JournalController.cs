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
    public class JournalController : ControllerBase
    {

        private readonly PolytechExamTestContext _context;

        public JournalController(PolytechExamTestContext context)
        {
            _context = context;
        }

        // GET: api/Journal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journal>>> GetJournal()
        {
            return await _context.Journal.ToListAsync();
        }

        // GET: api/Journal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journal>> GetJournal(int id)
        {
            var journal = await _context.Journal.FindAsync(id);

            if (journal == null)
            {
                return NotFound();
            }

            return journal;
        }

        // PUT: api/Journal/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournal(int id, Journal journal)
        {
            //if (id != journal.JournalId)
            //{
            //    return BadRequest();
            //}

            journal.JournalId = id;

            _context.Entry(journal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalExists(id))
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

        // POST: api/Journal
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Journal>> PostJournal(Journal journal)
        {
            _context.Journal.Add(journal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJournal", new { id = journal.JournalId }, journal);
        }

        // DELETE: api/Journal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Journal>> DeleteJournal(int id)
        {
            var journal = await _context.Journal.FindAsync(id);
            if (journal == null)
            {
                return NotFound();
            }

            _context.Journal.Remove(journal);
            await _context.SaveChangesAsync();

            return journal;
        }

        private bool JournalExists(int id)
        {
            return _context.Journal.Any(e => e.JournalId == id);
        }
    }
}
