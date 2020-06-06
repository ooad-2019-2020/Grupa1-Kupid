using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lovid_API
{
    public partial class LoviddbContext : DbContext
    {
        public LoviddbContext()
        {
        }

        public LoviddbContext(DbContextOptions<LoviddbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<KorisnikUchatu> KorisnikUchatu { get; set; }
        public virtual DbSet<Poruka> Poruka { get; set; }
        public virtual DbSet<Pratitelji> Pratitelji { get; set; }
        public virtual DbSet<Prijava> Prijava { get; set; }
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<RegistrovaniKorisnik> RegistrovaniKorisnik { get; set; }
        public virtual DbSet<TipKorisnika> TipKorisnika { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:lovid.database.windows.net,1433;Initial Catalog=Loviddb;Persist Security Info=False;User ID=ZejdC;Password=Adna-Ajla-Zejd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Lozinka).HasColumnName("lozinka");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<KorisnikUchatu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("KorisnikUChatu");

                entity.HasIndex(e => e.ChatId);

                entity.HasIndex(e => e.KorisnikId);

                entity.Property(e => e.ChatId).HasColumnName("chatID");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnikID");

                entity.HasOne(d => d.Chat)
                    .WithMany()
                    .HasForeignKey(d => d.ChatId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany()
                    .HasForeignKey(d => d.KorisnikId);
            });

            modelBuilder.Entity<Poruka>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.ChatId);

                entity.Property(e => e.ChatId).HasColumnName("chatID");

                entity.Property(e => e.Datum).HasColumnName("datum");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tekst).HasColumnName("tekst");

                entity.HasOne(d => d.Chat)
                    .WithMany()
                    .HasForeignKey(d => d.ChatId);
            });

            modelBuilder.Entity<Pratitelji>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pratitelji1).HasColumnName("pratitelji");
            });

            modelBuilder.Entity<Prijava>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum).HasColumnName("datum");

                entity.Property(e => e.Razlog).HasColumnName("razlog");
            });

            modelBuilder.Entity<Recenzija>(entity =>
            {
                entity.HasIndex(e => e.Korisnik)
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum).HasColumnName("datum");

                entity.Property(e => e.Korisnik).HasColumnName("korisnik");

                entity.Property(e => e.Ocjena).HasColumnName("ocjena");

                entity.Property(e => e.Tekst).HasColumnName("tekst");

                entity.HasOne(d => d.KorisnikNavigation)
                    .WithOne(p => p.Recenzija)
                    .HasForeignKey<Recenzija>(d => d.Korisnik);
            });

            modelBuilder.Entity<RegistrovaniKorisnik>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Biografija).HasColumnName("biografija");

                entity.Property(e => e.DatumRodjenja).HasColumnName("datumRodjenja");

                entity.Property(e => e.Drzava).HasColumnName("drzava");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Grad).HasColumnName("grad");

                entity.Property(e => e.IdKorisnika).HasColumnName("idKorisnika");

                entity.Property(e => e.Ime).HasColumnName("ime");

                entity.Property(e => e.Lozinka).HasColumnName("lozinka");

                entity.Property(e => e.Pratitelji).HasColumnName("pratitelji");

                entity.Property(e => e.Prezime).HasColumnName("prezime");

                entity.Property(e => e.Slika).HasColumnName("slika");

                entity.Property(e => e.Spol).HasColumnName("spol");

                entity.Property(e => e.Stanje).HasColumnName("stanje");

                entity.Property(e => e.TrajanjeVip).HasColumnName("trajanjeVIP");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RegistrovaniKorisnik)
                    .HasForeignKey<RegistrovaniKorisnik>(d => d.Id);
            });

            modelBuilder.Entity<TipKorisnika>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Naziv).HasColumnName("naziv");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TipKorisnika)
                    .HasForeignKey<TipKorisnika>(d => d.Id);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
