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
    public class MarkJournalController : ControllerBase
    {

        private readonly PolytechExamTestContext _context;

        public MarkJournalController(PolytechExamTestContext context)
        {
            _context = context;
        }

        // GET: api/MarkJournal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarkJournal>>> GetMarkJournal()
        {
            return await _context.MarkJournal.ToListAsync();
        }

        // GET: api/MarkJournal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarkJournal>> GetMarkJournal(int id)
        {
            var mark_journal = await _context.MarkJournal.FindAsync(id);

            if (mark_journal == null)
            {
                return NotFound();
            }

            return mark_journal;
        }

        // PUT: api/MarkJournal/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarkJournal(int id, MarkJournal mark_journal)
        {
            //if (id != mark_journal.MarkJournalId)
            //{
            //    return BadRequest();
            //}

            mark_journal.MarkJournalId = id;

            _context.Entry(mark_journal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkJournalExists(id))
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

        // POST: api/MarkJournal
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MarkJournal>> PostMarkJournal(MarkJournal mark_journal)
        {
            _context.MarkJournal.Add(mark_journal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarkJournal", new { id = mark_journal.MarkJournalId }, mark_journal);
        }

        // DELETE: api/MarkJournal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarkJournal>> DeleteMarkJournal(int id)
        {
            var mark_journal = await _context.MarkJournal.FindAsync(id);
            if (mark_journal == null)
            {
                return NotFound();
            }

            _context.MarkJournal.Remove(mark_journal);
            await _context.SaveChangesAsync();

            return mark_journal;
        }

        private bool MarkJournalExists(int id)
        {
            return _context.MarkJournal.Any(e => e.MarkJournalId == id);
        }
    }
}
