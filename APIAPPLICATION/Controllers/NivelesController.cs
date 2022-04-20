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
    public class NivelesController : ControllerBase
    {
        private readonly DbApiContext _context;

        public NivelesController(DbApiContext context)
        {
            _context = context;
        }

        // GET: api/Niveles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nivel>>> GetNiveles()
        {
            return await _context.Niveles.ToListAsync();
        }

        // GET: api/Niveles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nivel>> GetNivel(int id)
        {
            var nivel = await _context.Niveles.FindAsync(id);

            if (nivel == null)
            {
                return NotFound();
            }

            return nivel;
        }

        // PUT: api/Niveles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNivel(int id, Nivel nivel)
        {
            if (id != nivel.IdNivel)
            {
                return BadRequest();
            }

            _context.Entry(nivel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivelExists(id))
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

        // POST: api/Niveles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Nivel>> PostNivel(Nivel nivel)
        {
            _context.Niveles.Add(nivel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNivel", new { id = nivel.IdNivel }, nivel);
        }

        // DELETE: api/Niveles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nivel>> DeleteNivel(int id)
        {
            var nivel = await _context.Niveles.FindAsync(id);
            if (nivel == null)
            {
                return NotFound();
            }

            _context.Niveles.Remove(nivel);
            await _context.SaveChangesAsync();

            return nivel;
        }

        private bool NivelExists(int id)
        {
            return _context.Niveles.Any(e => e.IdNivel == id);
        }
    }
}
