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
    public class PasaportesController : ControllerBase
    {
        private readonly DbApiContext _context;

        public PasaportesController(DbApiContext context)
        {
            _context = context;
        }

        // GET: api/Pasaportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasaporte>>> GetPasaportes()
        {
            return await _context.Pasaportes.ToListAsync();
        }

        // GET: api/Pasaportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pasaporte>> GetPasaporte(int id)
        {
            var pasaporte = await _context.Pasaportes.FindAsync(id);

            if (pasaporte == null)
            {
                return NotFound();
            }

            return pasaporte;
        }

        // PUT: api/Pasaportes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasaporte(int id, Pasaporte pasaporte)
        {
            if (id != pasaporte.IdPasaporte)
            {
                return BadRequest();
            }

            _context.Entry(pasaporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasaporteExists(id))
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

        // POST: api/Pasaportes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pasaporte>> PostPasaporte(Pasaporte pasaporte)
        {
            _context.Pasaportes.Add(pasaporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasaporte", new { id = pasaporte.IdPasaporte }, pasaporte);
        }

        // DELETE: api/Pasaportes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pasaporte>> DeletePasaporte(int id)
        {
            var pasaporte = await _context.Pasaportes.FindAsync(id);
            if (pasaporte == null)
            {
                return NotFound();
            }

            _context.Pasaportes.Remove(pasaporte);
            await _context.SaveChangesAsync();

            return pasaporte;
        }

        private bool PasaporteExists(int id)
        {
            return _context.Pasaportes.Any(e => e.IdPasaporte == id);
        }
    }
}
