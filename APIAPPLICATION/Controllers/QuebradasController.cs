using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities;

namespace APIAPPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuebradasController : ControllerBase
    {
        private readonly DbApiContext _context;

        public QuebradasController(DbApiContext context)
        {
            _context = context;
        }

        // GET: api/Quebradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quebrada>>> GetQuebradas()
        {
            return await _context.Quebradas.ToListAsync();
        }

        // GET: api/Quebradas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quebrada>> GetQuebrada(int id)
        {
            var quebrada = await _context.Quebradas.FindAsync(id);

            if (quebrada == null)
            {
                return NotFound();
            }

            return quebrada;
        }

        // PUT: api/Quebradas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuebrada(int id, Quebrada quebrada)
        {
            if (id != quebrada.IdQuebrada)
            {
                return BadRequest();
            }

            _context.Entry(quebrada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuebradaExists(id))
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

        // POST: api/Quebradas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Quebrada>> PostQuebrada(Quebrada quebrada)
        {
            _context.Quebradas.Add(quebrada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuebrada", new { id = quebrada.IdQuebrada }, quebrada);
        }

        // DELETE: api/Quebradas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quebrada>> DeleteQuebrada(int id)
        {
            var quebrada = await _context.Quebradas.FindAsync(id);
            if (quebrada == null)
            {
                return NotFound();
            }

            _context.Quebradas.Remove(quebrada);
            await _context.SaveChangesAsync();

            return quebrada;
        }

        private bool QuebradaExists(int id)
        {
            return _context.Quebradas.Any(e => e.IdQuebrada == id);
        }
    }
}
