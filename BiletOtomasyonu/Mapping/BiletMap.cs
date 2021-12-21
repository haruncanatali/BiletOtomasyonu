using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.Mapping
{
    public class BiletMap:EntityTypeConfiguration<Bilet>
    {
        public BiletMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption
                    .Identity);

            this.ToTable("Tbl_Bilet");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.MusteriId).HasColumnName("MusteriId");
            this.Property(c => c.SeferId).HasColumnName("SeferId");
        }
    }
}