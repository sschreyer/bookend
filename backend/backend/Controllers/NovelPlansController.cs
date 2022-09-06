using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovelPlansController : ControllerBase
    {
        private readonly NovelPlansContext _context;

        public NovelPlansController(NovelPlansContext context)
        {
            _context = context;
        }

        // GET: api/NovelPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NovelPlan>>> GetNovelPlans()
        {
          if (_context.NovelPlans == null)
          {
              return NotFound();
          }
            return await _context.NovelPlans.ToListAsync();
        }

        // GET: api/NovelPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NovelPlan>> GetNovelPlan(long id)
        {
          if (_context.NovelPlans == null)
          {
              return NotFound();
          }
            var novelPlan = await _context.NovelPlans.FindAsync(id);

            if (novelPlan == null)
            {
                return NotFound();
            }

            return novelPlan;
        }

        // PUT: api/NovelPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNovelPlan(long id, NovelPlan novelPlan)
        {
            if (id != novelPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(novelPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NovelPlanExists(id))
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

        // POST: api/NovelPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NovelPlan>> PostNovelPlan(NovelPlan novelPlan)
        {
          if (_context.NovelPlans == null)
          {
              return Problem("Entity set 'NovelPlansContext.NovelPlans'  is null.");
          }
            _context.NovelPlans.Add(novelPlan);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetNovelPlan", new { id = novelPlan.Id }, novelPlan);
            return CreatedAtAction(nameof(GetNovelPlan), new { id = novelPlan.Id }, novelPlan);
        }

        // DELETE: api/NovelPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNovelPlan(long id)
        {
            if (_context.NovelPlans == null)
            {
                return NotFound();
            }
            var novelPlan = await _context.NovelPlans.FindAsync(id);
            if (novelPlan == null)
            {
                return NotFound();
            }

            _context.NovelPlans.Remove(novelPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NovelPlanExists(long id)
        {
            return (_context.NovelPlans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
