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
    public class SurucuDal:EntityRepositoryBase<Surucu,ProjeDbContext>,ISurucuDal
    {
        public Surucu GetEntity(Expression<Func<Surucu, bool>> filter)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return context.Tbl_Surucu.Include(c=>c.Otobusu).FirstOrDefault(filter);
            }
        }

        public List<Surucu> GetEntities(Expression<Func<Surucu, bool>> filter = null)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return filter == null ? context.Tbl_Surucu.Include(c=>c.Otobusu).ToList() : context.Tbl_Surucu.Include(c=>c.Otobusu).Where(filter).ToList();
            }
        }
    }
}