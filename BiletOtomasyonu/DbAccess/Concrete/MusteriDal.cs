using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BiletOtomasyonu.DbAccess.Abstract;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.DbAccess.Concrete
{
    public class MusteriDal:EntityRepositoryBase<Musteri,ProjeDbContext>,IMusteriDal
    {
        public Musteri GetEntity(Expression<Func<Musteri, bool>> filter)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return context.Tbl_Musteri.Include(c => c.Biletleri).FirstOrDefault(filter);
            }
        }

        public List<Musteri> GetEntities(Expression<Func<Musteri, bool>> filter = null)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return filter == null
                    ? context.Tbl_Musteri.Include(c => c.Biletleri).ToList()
                    : context.Tbl_Musteri.Include(c => c.Biletleri).Where(filter).ToList();
            }
        }
    }
}