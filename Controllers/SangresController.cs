using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SangresController : ControllerBase
    {
        private readonly Conexiones _context;

        public SangresController(Conexiones context)
        {
            _context = context;
        }

        // GET: api/Sangres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sangres>>> GetSangres()
        {
          if (_context.Sangres == null)
          {
              return NotFound();
          }
            return await _context.Sangres.ToListAsync();
        }

        // GET: api/Sangres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sangres>> GetSangres(int id)
        {
          if (_context.Sangres == null)
          {
              return NotFound();
          }
            var sangres = await _context.Sangres.FindAsync(id);

            if (sangres == null)
            {
                return NotFound();
            }

            return sangres;
        }

        // PUT: api/Sangres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSangres(int id, Sangres sangres)
        {
            if (id != sangres.id_tipo_sangre)
            {
                return BadRequest();
            }

            _context.Entry(sangres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SangresExists(id))
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

        // POST: api/Sangres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sangres>> PostSangres(Sangres sangres)
        {
          if (_context.Sangres == null)
          {
              return Problem("Entity set 'Conexiones.Sangres'  is null.");
          }
            _context.Sangres.Add(sangres);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSangres", new { id = sangres.id_tipo_sangre }, sangres);
        }

        // DELETE: api/Sangres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSangres(int id)
        {
            if (_context.Sangres == null)
            {
                return NotFound();
            }
            var sangres = await _context.Sangres.FindAsync(id);
            if (sangres == null)
            {
                return NotFound();
            }

            _context.Sangres.Remove(sangres);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SangresExists(int id)
        {
            return (_context.Sangres?.Any(e => e.id_tipo_sangre == id)).GetValueOrDefault();
        }
    }
}
