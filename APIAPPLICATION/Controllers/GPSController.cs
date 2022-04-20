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
    public class GPSController : ControllerBase
    {
        private readonly DbApiContext _context;

        public GPSController(DbApiContext context)
        {
            _context = context;
        }

        // GET: api/GPS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GPS>>> GetGPSes()
        {
            return await _context.GPSes.ToListAsync();
        }

        // GET: api/GPS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GPS>> GetGPS(int id)
        {
            var gPS = await _context.GPSes.FindAsync(id);

            if (gPS == null)
            {
                return NotFound();
            }

            return gPS;
        }

        // PUT: api/GPS/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGPS(int id, GPS gPS)
        {
            if (id != gPS.IdGps)
            {
                return BadRequest();
            }

            _context.Entry(gPS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GPSExists(id))
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

        // POST: api/GPS
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GPS>> PostGPS(GPS gPS)
        {
            _context.GPSes.Add(gPS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGPS", new { id = gPS.IdGps }, gPS);
        }

        // DELETE: api/GPS/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GPS>> DeleteGPS(int id)
        {
            var gPS = await _context.GPSes.FindAsync(id);
            if (gPS == null)
            {
                return NotFound();
            }

            _context.GPSes.Remove(gPS);
            await _context.SaveChangesAsync();

            return gPS;
        }

        private bool GPSExists(int id)
        {
            return _context.GPSes.Any(e => e.IdGps == id);
        }
    }
}
