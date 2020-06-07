using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lovid_API;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Lovid_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecenzijaController : ControllerBase
    {
        private readonly LoviddbContext _context;

        public RecenzijaController(LoviddbContext context)
        {
            _context = context;
        }

        // GET: api/Recenzija
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recenzija>>> GetRecenzija()
        {
            return await _context.Recenzija.ToListAsync();
        }

        // GET: api/Recenzija/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Recenzija>>> GetRecenzija(int id)
        {
            var list = await _context.Recenzija.ToListAsync();
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Recenzija value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list.Take(id).ToList();
        }

        // PUT: api/Recenzija/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecenzija(int id, Recenzija recenzija)
        {
            if (id != recenzija.Id)
            {
                return BadRequest();
            }

            _context.Entry(recenzija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecenzijaExists(id))
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

        // POST: api/Recenzija
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Recenzija>> PostRecenzija(Recenzija recenzija)
        {
            _context.Recenzija.Add(recenzija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecenzija", new { id = recenzija.Id }, recenzija);
        }

        // DELETE: api/Recenzija/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recenzija>> DeleteRecenzija(int id)
        {
            var recenzija = await _context.Recenzija.FindAsync(id);
            if (recenzija == null)
            {
                return NotFound();
            }

            _context.Recenzija.Remove(recenzija);
            await _context.SaveChangesAsync();

            return recenzija;
        }

        private bool RecenzijaExists(int id)
        {
            return _context.Recenzija.Any(e => e.Id == id);
        }
    }
}
