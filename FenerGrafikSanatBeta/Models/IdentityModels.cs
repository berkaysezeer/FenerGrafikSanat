﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FenerGrafikSanatBeta.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Yorum> Yorumlar { get; set; }
        //public virtual ICollection<Tasarim> Tasarimlar { get; set; }
        public virtual ICollection<KullaniciTasarim> KullaniciTasarimlar { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Baglanti", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasarim>()
                .HasRequired(x => x.Kategori)
                .WithMany(x => x.Tasarimlar)
                .HasForeignKey(x => x.KategoriId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KullaniciTasarim>().HasKey(sc => new { sc.KullaniciId, sc.TasarimId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tasarim> Tasarimlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<KullaniciTasarim> KullaniciTasarimlar { get; set; }
    }
}