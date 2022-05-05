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
    public class IncidentesController : ControllerBase
    {
        private readonly DbApiContext _context;

        public IncidentesController(DbApiContext context)
        {
            _context = context;
        }


        //[HttpGet("GetIncidenteWithUsuario")]
        //public async Task<ActionResult<IEnumerable<Incidente>>> GetIncidentesWithUsuario()
        //{
        //    var motivos = await (from incidente in _context.Incidentes
        //                         join usuario in _context.Usuarios on incidente.IdUsuario equals usuario.IdUsuario
        //                         join  
        //                         orderby incidente.IdIncidente ascending

        //                         select new Incidente
        //                         {
        //                             IdIncidente = incidente.IdIncidente,
        //                             Descripcion=incidente.Descripcion,
        //                             Imagen=incidente.Imagen,
        //                             FechaRegistro=incidente.FechaRegistro,
        //                             FechaActualizacion=incidente.FechaActualizacion,
        //                             Resuelto=incidente.Resuelto,
        //                             IdUsuario=incidente.IdUsuario,
        //                             Usuario=usuario
        //                         }

        //      ).ToListAsync();
        //    return motivos;
        //}


        // GET: api/Incidentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidente>>> GetIncidentes()
        {
            //return await _context.Incidentes.ToListAsync();
            var incidentes = await (from incidente in _context.Incidentes
                                 join usuario in _context.Usuarios on incidente.IdUsuario equals usuario.IdUsuario
                                 join quebrada in _context.Quebradas on incidente.IdQuebrada equals quebrada.IdQuebrada
                                 join motivo in _context.Motivos on incidente.IdMotivo equals motivo.IdMotivo
                                 join coord in _context.GPSes on incidente.IdGPS equals coord.IdGps into pJoinData
                                 from GpsNullable in pJoinData.DefaultIfEmpty()
                                 orderby incidente.IdIncidente ascending

                                 select new Incidente
                                 {
                                     IdIncidente = incidente.IdIncidente,
                                     Descripcion = incidente.Descripcion,
                                     Imagen = incidente.Imagen,
                                     FechaRegistro = incidente.FechaRegistro,
                                     FechaActualizacion = incidente.FechaActualizacion,
                                     Resuelto = incidente.Resuelto,
                                     IdUsuario = incidente.IdUsuario,
                                     Usuario = usuario,
                                     Quebrada= quebrada,
                                     Motivo= motivo,
                                     IdGPS=incidente.IdGPS,
                                     IdMotivo=incidente.IdMotivo,
                                     IdQuebrada=incidente.IdQuebrada,
                                     GPS= GpsNullable != null ? GpsNullable : null

                                 }

                                           ).ToListAsync();
            return incidentes;
        }

        // GET: api/Incidentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incidente>> GetIncidente(int id)
        {
            var incidente = await _context.Incidentes.FindAsync(id);

            if (incidente == null)
            {
                return NotFound();
            }

            return incidente;
        }

        [HttpGet("GetLastDays/{dias}")]
        public async Task<ActionResult<IEnumerable<Incidente>>> GetIncidenteDias(int dias)
        {
            //var incidente = await _context.Incidentes.FindAsync(id);

            //if (incidente == null)
            //{
            //    return NotFound();
            //}

            var incidentes = await (from incidente in _context.Incidentes
                                    join usuario in _context.Usuarios on incidente.IdUsuario equals usuario.IdUsuario
                                    join quebrada in _context.Quebradas on incidente.IdQuebrada equals quebrada.IdQuebrada
                                    join motivo in _context.Motivos on incidente.IdMotivo equals motivo.IdMotivo
                                    join coord in _context.GPSes on incidente.IdGPS equals coord.IdGps into pJoinData
                                    from GpsNullable in pJoinData.DefaultIfEmpty()
                                    where incidente.FechaRegistro >= DateTime.Now.AddDays(-dias)
                                    orderby incidente.FechaRegistro ascending

                                    select new Incidente
                                    {
                                        IdIncidente = incidente.IdIncidente,
                                        Descripcion = incidente.Descripcion,
                                        FechaRegistro = incidente.FechaRegistro,
                                        FechaActualizacion = incidente.FechaActualizacion,
                                        Resuelto = incidente.Resuelto,
                                        IdUsuario = incidente.IdUsuario,
                                        Usuario = usuario,
                                        Quebrada = quebrada,
                                        Motivo = motivo,
                                        IdGPS = incidente.IdGPS,
                                        IdMotivo = incidente.IdMotivo,
                                        IdQuebrada = incidente.IdQuebrada,
                                        GPS = GpsNullable != null ? GpsNullable : null

                                    }

                                          ).ToListAsync();
            return incidentes;

        }

        // PUT: api/Incidentes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidente(int id, Incidente incidente)
        {
            if (id != incidente.IdIncidente)
            {
                return BadRequest();
            }

            _context.Entry(incidente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidenteExists(id))
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


        [HttpPut("Update_Imagen/{id}")]
        public async Task<ActionResult<Incidente>> PutAlertaField(int id, Incidente incidente)
        {
            if (id != incidente.IdIncidente)
            {
                return BadRequest();
            }

            var incident = await _context.Incidentes.FindAsync(incidente.IdIncidente);

            if (incident == null)
            {
                // throw error,
                return NotFound();
            }

            incident.Imagen = incidente.Imagen;
            _context.Update(incident);
            _context.SaveChanges();

            return incident;
        }




        // POST: api/Incidentes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Incidente>> PostIncidente(Incidente incidente)
        {
            _context.Incidentes.Add(incidente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidente", new { id = incidente.IdIncidente }, incidente);
        }

        // DELETE: api/Incidentes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Incidente>> DeleteIncidente(int id)
        {
            var incidente = await _context.Incidentes.FindAsync(id);
            if (incidente == null)
            {
                return NotFound();
            }

            _context.Incidentes.Remove(incidente);
            await _context.SaveChangesAsync();

            return incidente;
        }

        private bool IncidenteExists(int id)
        {
            return _context.Incidentes.Any(e => e.IdIncidente == id);
        }
    }
}
