﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BiletOtomasyonu.Mapping;

namespace BiletOtomasyonu.Models
{
    public class ProjeDbContext:DbContext
    {
        public DbSet<Otobus> Tbl_Otobus { get; set; }
        public DbSet<Sefer> Tbl_Sefer { get; set; }
        public DbSet<Sehir> Tbl_Sehir { get; set; }
        public DbSet<Musteri> Tbl_Musteri { get; set; }
        public DbSet<Bilet> Tbl_Bilet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //İlişkiler
            modelBuilder.Entity<Otobus>().HasMany(c => c.Seferleri).WithRequired(c => c.Otobusu)
                .HasForeignKey(c => c.OtobusId);
            modelBuilder.Entity<Sefer>().HasMany(c => c.Biletleri).WithRequired(c => c.Seferi)
                .HasForeignKey(c => c.SeferId);
            modelBuilder.Entity<Musteri>().HasMany(c => c.Biletleri).WithRequired(c => c.Musterisi)
                .HasForeignKey(c => c.MusteriId);
            
            //Veritabanı tabloları ayarları
            modelBuilder.Configurations.Add(new BiletMap());
            modelBuilder.Configurations.Add(new MusteriMap());
            modelBuilder.Configurations.Add(new OtobusMap());
            modelBuilder.Configurations.Add(new SeferMap());
            modelBuilder.Configurations.Add(new SehirMap());
        }
    }
}