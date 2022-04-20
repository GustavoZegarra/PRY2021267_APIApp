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
    public class WifisController : ControllerBase
    {
        private readonly DbApiContext _context;

        public WifisController(DbApiContext context)
        {
            _context = context;
        }

        // GET: api/Wifis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wifi>>> GetWifis()
        {
            return await _context.Wifis.ToListAsync();
        }

        // GET: api/Wifis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wifi>> GetWifi(int id)
        {
            var wifi = await _context.Wifis.FindAsync(id);

            if (wifi == null)
            {
                return NotFound();
            }

            return wifi;
        }

        // PUT: api/Wifis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWifi(int id, Wifi wifi)
        {
            if (id != wifi.IdWifi)
            {
                return BadRequest();
            }

            _context.Entry(wifi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WifiExists(id))
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

        // POST: api/Wifis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Wifi>> PostWifi(Wifi wifi)
        {
            _context.Wifis.Add(wifi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWifi", new { id = wifi.IdWifi }, wifi);
        }

        // DELETE: api/Wifis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wifi>> DeleteWifi(int id)
        {
            var wifi = await _context.Wifis.FindAsync(id);
            if (wifi == null)
            {
                return NotFound();
            }

            _context.Wifis.Remove(wifi);
            await _context.SaveChangesAsync();

            return wifi;
        }

        private bool WifiExists(int id)
        {
            return _context.Wifis.Any(e => e.IdWifi == id);
        }
    }
}
