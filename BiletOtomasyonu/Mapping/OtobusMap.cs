using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.Mapping
{
    public class OtobusMap:EntityTypeConfiguration<Otobus>
    {
        public OtobusMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption
                    .Identity);

            this.ToTable("Tbl_Otobus");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Plaka).HasColumnName("Plaka");
            this.Property(c => c.Marka).HasColumnName("Marka");
            this.Property(c => c.Model).HasColumnName("Model");
            this.Property(c => c.Firma).HasColumnName("Firma");
            this.Property(c => c.Mevcut).HasColumnName("Mevcut");
            this.Property(c => c.Ozellikler).HasColumnName("Ozellikler");
        }
    }
}