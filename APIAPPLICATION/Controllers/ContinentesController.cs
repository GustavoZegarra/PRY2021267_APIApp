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
    public class ContinentesController : ControllerBase
    {
        private readonly DbApiContext _context;

        public ContinentesController(DbApiContext context)
        {
            _context = context;
        }

        // GET: api/Continentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Continente>>> GetContinentes()
        {
            return await _context.Continentes.ToListAsync();
        }

        // GET: api/Continentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Continente>> GetContinente(int id)
        {
            var continente = await _context.Continentes.FindAsync(id);

            if (continente == null)
            {
                return NotFound();
            }

            return continente;
        }

        // PUT: api/Continentes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContinente(int id, Continente continente)
        {
            if (id != continente.IdContinente)
            {
                return BadRequest();
            }

            _context.Entry(continente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContinenteExists(id))
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

        // POST: api/Continentes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Continente>> PostContinente(Continente continente)
        {
            _context.Continentes.Add(continente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContinente", new { id = continente.IdContinente }, continente);
        }

        // DELETE: api/Continentes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Continente>> DeleteContinente(int id)
        {
            var continente = await _context.Continentes.FindAsync(id);
            if (continente == null)
            {
                return NotFound();
            }

            _context.Continentes.Remove(continente);
            await _context.SaveChangesAsync();

            return continente;
        }

        private bool ContinenteExists(int id)
        {
            return _context.Continentes.Any(e => e.IdContinente == id);
        }
    }
}
