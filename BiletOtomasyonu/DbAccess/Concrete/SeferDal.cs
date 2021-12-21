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
    public class SeferDal:EntityRepositoryBase<Sefer,ProjeDbContext>,ISeferDal
    {
        public Sefer GetEntity(Expression<Func<Sefer, bool>> filter)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return context.Tbl_Sefer.Include(c => c.Biletleri).Include(c => c.Otobusu).FirstOrDefault(filter);
            }
        }

        public List<Sefer> GetEntities(Expression<Func<Sefer, bool>> filter = null)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return filter == null
                    ? context.Tbl_Sefer.Include(c => c.Biletleri).Include(c => c.Otobusu).ToList()
                    : context.Tbl_Sefer.Include(c => c.Biletleri).Include(c => c.Otobusu).Where(filter).ToList();
            }
        }
    }
}