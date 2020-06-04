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
    public class ChatController : Controller
    {
        private readonly LovidContext _context;

        public ChatController(LovidContext context)
        {
            _context = context;
        }

        // GET: Chat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chat.ToListAsync());
        }

        // GET: Chat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatDB = await _context.Chat
                .FirstOrDefaultAsync(m => m.id == id);
            if (chatDB == null)
            {
                return NotFound();
            }

            return View(chatDB);
        }

        // GET: Chat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id")] ChatDB chatDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatDB);
        }

        // GET: Chat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatDB = await _context.Chat.FindAsync(id);
            if (chatDB == null)
            {
                return NotFound();
            }
            return View(chatDB);
        }

        // POST: Chat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id")] ChatDB chatDB)
        {
            if (id != chatDB.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatDBExists(chatDB.id))
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
            return View(chatDB);
        }

        // GET: Chat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatDB = await _context.Chat
                .FirstOrDefaultAsync(m => m.id == id);
            if (chatDB == null)
            {
                return NotFound();
            }

            return View(chatDB);
        }

        // POST: Chat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chatDB = await _context.Chat.FindAsync(id);
            _context.Chat.Remove(chatDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatDBExists(int id)
        {
            return _context.Chat.Any(e => e.id == id);
        }
    }
}
