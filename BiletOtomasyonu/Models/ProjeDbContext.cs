using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using BiletOtomasyonu.Mapping;

namespace BiletOtomasyonu.Models
{
    public class ProjeDbContext:DbContext
    {
        public ProjeDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Otobus> Tbl_Otobus { get; set; }
        public DbSet<Sefer> Tbl_Sefer { get; set; }
        public DbSet<Sehir> Tbl_Sehir { get; set; }
        public DbSet<Musteri> Tbl_Musteri { get; set; }
        public DbSet<Bilet> Tbl_Bilet { get; set; }
        public DbSet<Surucu> Tbl_Surucu { get; set; }
        public DbSet<Sorumlu> Tbl_Sorumlu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //İlişkiler
            modelBuilder.Entity<Otobus>().HasMany(c => c.Seferleri).WithRequired(c => c.Otobusu)
                .HasForeignKey(c => c.OtobusId);
            modelBuilder.Entity<Sefer>().HasMany(c => c.Biletleri).WithRequired(c => c.Seferi)
                .HasForeignKey(c => c.SeferId);
            modelBuilder.Entity<Musteri>().HasMany(c => c.Biletleri).WithRequired(c => c.Musterisi)
                .HasForeignKey(c => c.MusteriId);
            modelBuilder.Entity<Otobus>().HasMany(c => c.Suruculeri).WithRequired(c => c.Otobusu)
                .HasForeignKey(c => c.OtobusId);
            modelBuilder.Entity<Sorumlu>().HasMany(c => c.SattigiBiletler).WithRequired(c => c.Sorumlusu)
                .HasForeignKey(c => c.SorumluId);
            
            //Veritabanı tabloları ayarları
            modelBuilder.Configurations.Add(new BiletMap());
            modelBuilder.Configurations.Add(new MusteriMap());
            modelBuilder.Configurations.Add(new OtobusMap());
            modelBuilder.Configurations.Add(new SeferMap());
            modelBuilder.Configurations.Add(new SehirMap());
            modelBuilder.Configurations.Add(new SurucuMap());
            modelBuilder.Configurations.Add(new SorumluMap());
        }
    }
}