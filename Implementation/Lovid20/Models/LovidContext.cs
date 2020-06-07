using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lovid20.Models
{
    public class LovidContext: DbContext
    {
        public LovidContext(DbContextOptions<LovidContext> options):base(options)
        { }

        public DbSet<RegistrovaniKorisnikDB> Korisnik { get; set; }
        public DbSet<TipKorisnika> TipKorisnika { get; set; }
        public DbSet<PrijavaDB> Prijava { get; set; }
        public DbSet<RecenzijaDB> Recenzija { get; set; }
        public DbSet<Pratitelji> Pratitelji { get; set; }
        public DbSet<KorisnikUChatu> KorisnikUChatu { get; set; }
        public DbSet<ChatDB> Chat { get; set; }
        public DbSet<PorukaDB> Poruka { get; set; }
        public DbSet<AdministratorDB> Administrator { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrovaniKorisnikDB>().ToTable("RegistrovaniKorisnik").Property(i=>i.idKorisnika).ValueGeneratedOnAdd();
            modelBuilder.Entity<TipKorisnika>().ToTable("TipKorisnika");
            modelBuilder.Entity<PrijavaDB>().ToTable("Prijava");
            modelBuilder.Entity<RecenzijaDB>().ToTable("Recenzija");
            modelBuilder.Entity<Pratitelji>().ToTable("Pratitelji").HasNoKey();
            modelBuilder.Entity<KorisnikUChatu>().ToTable("KorisnikUChatu").HasNoKey();
            modelBuilder.Entity<ChatDB>().ToTable("Chat");
            modelBuilder.Entity<PorukaDB>().ToTable("Poruka").HasNoKey();
            modelBuilder.Entity<AdministratorDB>().ToTable("Administrator");
        }
    }
}
