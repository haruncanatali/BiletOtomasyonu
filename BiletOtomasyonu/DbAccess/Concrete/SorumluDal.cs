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
    public class SorumluDal:EntityRepositoryBase<Sorumlu,ProjeDbContext>,ISorumluDal
    {
        public Sorumlu GetEntity(Expression<Func<Sorumlu, bool>> filter)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return context.Tbl_Sorumlu.Include(c => c.SattigiBiletler).FirstOrDefault(filter);
            }
        }

        public List<Sorumlu> GetEntities(Expression<Func<Sorumlu, bool>> filter = null)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return filter == null ? context.Tbl_Sorumlu.Include(c=>c.SattigiBiletler).ToList() : context.Tbl_Sorumlu
                    .Include(c => c.SattigiBiletler).Where(filter).ToList();
            }
        }
    }
}