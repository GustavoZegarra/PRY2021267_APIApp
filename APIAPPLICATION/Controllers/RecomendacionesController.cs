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
    public class RecomendacionesController : ControllerBase
    {
        private readonly DbApiContext _context;

        public RecomendacionesController(DbApiContext context)
        {
            _context = context;
        }

        // GET: api/Recomendaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recomendacion>>> GetRecomendaciones()
        {
            return await _context.Recomendaciones.ToListAsync();
        }

        // GET: api/Recomendaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recomendacion>> GetRecomendacion(int id)
        {
            var recomendacion = await _context.Recomendaciones.FindAsync(id);

            if (recomendacion == null)
            {
                return NotFound();
            }

            return recomendacion;
        }

        // PUT: api/Recomendaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecomendacion(int id, Recomendacion recomendacion)
        {
            if (id != recomendacion.IdRecomendacion)
            {
                return BadRequest();
            }

            _context.Entry(recomendacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecomendacionExists(id))
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

        // POST: api/Recomendaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Recomendacion>> PostRecomendacion(Recomendacion recomendacion)
        {
            _context.Recomendaciones.Add(recomendacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecomendacion", new { id = recomendacion.IdRecomendacion }, recomendacion);
        }

        // DELETE: api/Recomendaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recomendacion>> DeleteRecomendacion(int id)
        {
            var recomendacion = await _context.Recomendaciones.FindAsync(id);
            if (recomendacion == null)
            {
                return NotFound();
            }

            _context.Recomendaciones.Remove(recomendacion);
            await _context.SaveChangesAsync();

            return recomendacion;
        }

        private bool RecomendacionExists(int id)
        {
            return _context.Recomendaciones.Any(e => e.IdRecomendacion == id);
        }
    }
}
