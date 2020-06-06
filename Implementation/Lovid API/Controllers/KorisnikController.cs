using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lovid_API;

namespace Lovid_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly LoviddbContext _context;

        public KorisnikController(LoviddbContext context)
        {
            _context = context;
        }

        // GET: api/Korisnik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrovaniKorisnik>>> GetRegistrovaniKorisnik()
        {
            return await _context.RegistrovaniKorisnik.ToListAsync();
        }

        // GET: api/Korisnik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrovaniKorisnik>> GetRegistrovaniKorisnik(int id)
        {
            var registrovaniKorisnik = await _context.RegistrovaniKorisnik.FindAsync(id);

            if (registrovaniKorisnik == null)
            {
                return NotFound();
            }

            return registrovaniKorisnik;
        }

        // PUT: api/Korisnik/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrovaniKorisnik(int id, RegistrovaniKorisnik registrovaniKorisnik)
        {
            if (id != registrovaniKorisnik.Id)
            {
                return BadRequest();
            }

            _context.Entry(registrovaniKorisnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrovaniKorisnikExists(id))
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

        // POST: api/Korisnik
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegistrovaniKorisnik>> PostRegistrovaniKorisnik(RegistrovaniKorisnik registrovaniKorisnik)
        {
            _context.RegistrovaniKorisnik.Add(registrovaniKorisnik);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegistrovaniKorisnikExists(registrovaniKorisnik.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegistrovaniKorisnik", new { id = registrovaniKorisnik.Id }, registrovaniKorisnik);
        }

        // DELETE: api/Korisnik/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistrovaniKorisnik>> DeleteRegistrovaniKorisnik(int id)
        {
            var registrovaniKorisnik = await _context.RegistrovaniKorisnik.FindAsync(id);
            if (registrovaniKorisnik == null)
            {
                return NotFound();
            }

            _context.RegistrovaniKorisnik.Remove(registrovaniKorisnik);
            await _context.SaveChangesAsync();

            return registrovaniKorisnik;
        }

        private bool RegistrovaniKorisnikExists(int id)
        {
            return _context.RegistrovaniKorisnik.Any(e => e.Id == id);
        }
    }
}
