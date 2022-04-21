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
    public class DNIsController : ControllerBase
    {
        private readonly DbApiContext _context;

        public DNIsController(DbApiContext context)
        {
            _context = context;
        }


        [HttpGet("GetDniByNombre/{nombre}")]
        public async Task<ActionResult<DNI>> GetDniByNombre(string nombre)
        {
            //return await _context.Motivos.ToListAsync();
            //var usuario = _context.Usuarios.ToList();
            var dni = await _context.DNIs.FirstOrDefaultAsync(u => u.Dni == nombre);
            if (dni == null)
            {
                return NotFound(new { message = "El dni no existe" });
            }
            return dni;
        }

        // GET: api/DNIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DNI>>> GetDNIs()
        {
            return await _context.DNIs.ToListAsync();
        }

        // GET: api/DNIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DNI>> GetDNI(int id)
        {
            var dNI = await _context.DNIs.FindAsync(id);

            if (dNI == null)
            {
                return NotFound();
            }

            return dNI;
        }

        // PUT: api/DNIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDNI(int id, DNI dNI)
        {
            if (id != dNI.IdDni)
            {
                return BadRequest();
            }

            _context.Entry(dNI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DNIExists(id))
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

        // POST: api/DNIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DNI>> PostDNI(DNI dNI)
        {
            var dnis = _context.DNIs.ToList();
            bool flag = false;

            foreach (DNI dni in dnis)
            {
                if (dni.Dni == dNI.Dni)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                return BadRequest(new { message = "El dni ya existe" });
            }


            _context.DNIs.Add(dNI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDNI", new { id = dNI.IdDni }, dNI);
        }

        // DELETE: api/DNIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DNI>> DeleteDNI(int id)
        {
            var dNI = await _context.DNIs.FindAsync(id);
            if (dNI == null)
            {
                return NotFound();
            }

            _context.DNIs.Remove(dNI);
            await _context.SaveChangesAsync();

            return dNI;
        }

        private bool DNIExists(int id)
        {
            return _context.DNIs.Any(e => e.IdDni == id);
        }
    }
}
