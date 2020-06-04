using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lovid20.Models;

namespace Lovid20.Controllers
{
    public class ProfileController : Controller
    {
        private readonly LovidContext _context;

        public ProfileController(LovidContext context)
        {
            _context = context;
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            return View(await _context.Korisnik.ToListAsync());
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrovaniKorisnikDB = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.id == id);
            if (registrovaniKorisnikDB == null)
            {
                return NotFound();
            }

            return View(registrovaniKorisnikDB);
        }

        // GET: Profile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idKorisnika,lozinka,ime,prezime,drzava,grad,username,slika,email,biografija,datumRodjenja,spol,stanje,trajanjeVIP")] RegistrovaniKorisnikDB registrovaniKorisnikDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrovaniKorisnikDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrovaniKorisnikDB);
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrovaniKorisnikDB = await _context.Korisnik.FindAsync(id);
            if (registrovaniKorisnikDB == null)
            {
                return NotFound();
            }
            return View(registrovaniKorisnikDB);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("idKorisnika,lozinka,ime,prezime,drzava,grad,username,slika,email,biografija,datumRodjenja,spol,stanje,trajanjeVIP")] RegistrovaniKorisnikDB registrovaniKorisnikDB)
        {
            if (id != registrovaniKorisnikDB.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrovaniKorisnikDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrovaniKorisnikDBExists(registrovaniKorisnikDB.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registrovaniKorisnikDB);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrovaniKorisnikDB = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.id == id);
            if (registrovaniKorisnikDB == null)
            {
                return NotFound();
            }

            return View(registrovaniKorisnikDB);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var registrovaniKorisnikDB = await _context.Korisnik.FindAsync(id);
            _context.Korisnik.Remove(registrovaniKorisnikDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrovaniKorisnikDBExists(int? id)
        {
            return _context.Korisnik.Any(e => e.id == id);
        }
    }
}
