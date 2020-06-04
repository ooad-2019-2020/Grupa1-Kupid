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
    public class AdministratorController : Controller
    {
        private readonly LovidContext _context;

        public AdministratorController(LovidContext context)
        {
            _context = context;
        }

        // GET: Administrator
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administrator.ToListAsync());
        }

        // GET: Administrator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administratorDB = await _context.Administrator
                .FirstOrDefaultAsync(m => m.id == id);
            if (administratorDB == null)
            {
                return NotFound();
            }

            return View(administratorDB);
        }

        // GET: Administrator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,email,lozinka")] AdministratorDB administratorDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administratorDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administratorDB);
        }

        // GET: Administrator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administratorDB = await _context.Administrator.FindAsync(id);
            if (administratorDB == null)
            {
                return NotFound();
            }
            return View(administratorDB);
        }

        // POST: Administrator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,email,lozinka")] AdministratorDB administratorDB)
        {
            if (id != administratorDB.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administratorDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministratorDBExists(administratorDB.id))
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
            return View(administratorDB);
        }

        // GET: Administrator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administratorDB = await _context.Administrator
                .FirstOrDefaultAsync(m => m.id == id);
            if (administratorDB == null)
            {
                return NotFound();
            }

            return View(administratorDB);
        }

        // POST: Administrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administratorDB = await _context.Administrator.FindAsync(id);
            _context.Administrator.Remove(administratorDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministratorDBExists(int id)
        {
            return _context.Administrator.Any(e => e.id == id);
        }
    }
}
