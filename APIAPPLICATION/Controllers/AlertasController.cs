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
    public class AlertasController : ControllerBase
    {
        private readonly DbApiContext _context;

        public AlertasController(DbApiContext context)
        {
            _context = context;
        }

        // GET: api/Alertas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> GetAlertas()
        {
            return await _context.Alertas.ToListAsync();
        }

        // GET: api/Alertas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> GetAlerta(int id)
        {
            var alerta = await _context.Alertas.FindAsync(id);

            if (alerta == null)
            {
                return NotFound();
            }

            return alerta;
        }

        // PUT: api/Alertas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlerta(int id, Alerta alerta)
        {
            if (id != alerta.IdAlerta)
            {
                return BadRequest();
            }

            _context.Entry(alerta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertaExists(id))
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

        // POST: api/Alertas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Alerta>> PostAlerta(Alerta alerta)
        {
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlerta", new { id = alerta.IdAlerta }, alerta);
        }

        // DELETE: api/Alertas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Alerta>> DeleteAlerta(int id)
        {
            var alerta = await _context.Alertas.FindAsync(id);
            if (alerta == null)
            {
                return NotFound();
            }

            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();

            return alerta;
        }

        private bool AlertaExists(int id)
        {
            return _context.Alertas.Any(e => e.IdAlerta == id);
        }
    }
}
