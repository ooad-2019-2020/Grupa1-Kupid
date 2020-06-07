using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lovid20.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Lovid20.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LovidContext context;
        public HomeController(LovidContext lovidContext)
        {
            context = lovidContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()

        {
            return View();
        }
        public IActionResult Packages()
        {
            return View();
        }
        public async Task<IActionResult> Reviews()
        {
            string apiurl = "https://lovidapi.azurewebsites.net";
            List<RecenzijaDB> recenzije = new List<RecenzijaDB>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiurl);
                client.DefaultRequestHeaders.Clear();
                //definisanje formata koji želimo prihvatiti
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Asinhrono slanje zahtjeva za podacima o studentima
                HttpResponseMessage Res = await client.GetAsync("api/Recenzija/3");
                if (Res.IsSuccessStatusCode)
                {
                    //spremanje podataka dobijenih iz responsa
                    var response = Res.Content.ReadAsStringAsync().Result;
                    //Deserijalizacija responsa dobijenog iz apija i pretvaranje u
                    recenzije = JsonConvert.DeserializeObject<List<RecenzijaDB>>(response);
                }
            }
            return View(recenzije);
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(String username, String password)
        {
            var admin = context.Administrator.Where(a => a.email.Equals(username) && a.lozinka.Equals(password));
            var korisnik = context.Korisnik.Where(k => (k.username.Equals(username) || k.email.Equals(username) && k.lozinka.Equals(password)));
            if (korisnik.Count() == 0 && admin.Count() == 0)
            {
                ViewBag.Message = "Pogrešni pristupni podaci!";
                return View();
            }
            else if (korisnik.Count() != 0)
            {
                TempData["korisnik"] = Newtonsoft.Json.JsonConvert.SerializeObject(korisnik.ToList().ElementAt(0));
                return RedirectToAction("MyProfile", "Profile");
            }
            return RedirectToAction("Index", "Admin", new Microsoft.AspNetCore.Routing.RouteValueDictionary(admin.ElementAt(0)));
        }
        [HttpPost]
        public IActionResult Register(String username, String password, String surname, String email)
        {
            if (check(username,password,surname,email))
            {
                var korisnik = new RegistrovaniKorisnikDB(username, password, surname, email);
                context.Korisnik.Add(korisnik);
                context.SaveChanges();
                ViewBag.Ime = username;
                ViewBag.Surname = surname;
                return RedirectToAction("MyProfile", "Profile");
            }
            ViewBag.Message = "Pogrešni podaci!";
            return View();
        }

        private bool check(String username, String password, String surname, String email)
        {
            if (username == null || username.Length < 1) return false;
            if (password == null || password.Length < 6) return false;
            if (surname == null || surname.Length < 1) return false;
            if (email == null || !email.Contains('@')) return false;
            return true;
        }

    }
}
