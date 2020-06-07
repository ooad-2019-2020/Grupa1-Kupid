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
            return View();
        }
        public async Task<IActionResult> MyProfile()
        {
            var korisnik = Newtonsoft.Json.JsonConvert.DeserializeObject<RegistrovaniKorisnikDB>((String)TempData["korisnik"]);
            return View(korisnik);
        }
    }
}
