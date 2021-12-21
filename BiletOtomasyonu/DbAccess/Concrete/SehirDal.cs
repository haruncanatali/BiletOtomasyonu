using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BiletOtomasyonu.DbAccess.Abstract;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.DbAccess.Concrete
{
    public class SehirDal:EntityRepositoryBase<Sehir,ProjeDbContext>,ISehirDal
    {
        public Sehir GetEntity(Expression<Func<Sehir, bool>> filter)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return context.Tbl_Sehir.FirstOrDefault(filter);
            }
        }

        public List<Sehir> GetEntities(Expression<Func<Sehir, bool>> filter = null)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return filter == null ? context.Tbl_Sehir.ToList() : context.Tbl_Sehir.Where(filter).ToList();
            }
        }
    }
}