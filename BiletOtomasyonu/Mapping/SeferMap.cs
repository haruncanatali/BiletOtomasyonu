using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.Mapping
{
    public class SeferMap:EntityTypeConfiguration<Sefer>
    {
        public SeferMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption
                    .Identity);

            this.ToTable("Tbl_Sefer");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.KalkisYeri).HasColumnName("KalkisYeri");
            this.Property(c => c.VarisYeri).HasColumnName("VarisYeri");
            this.Property(c => c.KalkisZamani).HasColumnName("KalkisZamani");
            this.Property(c => c.TahminiVarisZamani).HasColumnName("TahminiVarisZamani");
            this.Property(c => c.Ucret).HasColumnName("SeferUcreti");
        }
    }
}