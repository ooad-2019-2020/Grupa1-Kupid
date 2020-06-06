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
    public class AdministratorsController : ControllerBase
    {
        private readonly LoviddbContext _context;

        public AdministratorsController(LoviddbContext context)
        {
            _context = context;
        }

        // GET: api/Administrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrator>>> GetAdministrator()
        {
            return await _context.Administrator.ToListAsync();
        }

        // GET: api/Administrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrator>> GetAdministrator(int id)
        {
            var administrator = await _context.Administrator.FindAsync(id);

            if (administrator == null)
            {
                return NotFound();
            }

            return administrator;
        }

        // PUT: api/Administrators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrator(int id, Administrator administrator)
        {
            if (id != administrator.Id)
            {
                return BadRequest();
            }

            _context.Entry(administrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(id))
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

        // POST: api/Administrators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Administrator>> PostAdministrator(Administrator administrator)
        {
            _context.Administrator.Add(administrator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrator", new { id = administrator.Id }, administrator);
        }

        // DELETE: api/Administrators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Administrator>> DeleteAdministrator(int id)
        {
            var administrator = await _context.Administrator.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }

            _context.Administrator.Remove(administrator);
            await _context.SaveChangesAsync();

            return administrator;
        }

        private bool AdministratorExists(int id)
        {
            return _context.Administrator.Any(e => e.Id == id);
        }
    }
}
