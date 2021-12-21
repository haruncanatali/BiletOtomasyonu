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
    public class BiletDal:EntityRepositoryBase<Bilet,ProjeDbContext>,IBiletDal
    {
        public Bilet GetEntity(Expression<Func<Bilet, bool>> filter)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return context.Tbl_Bilet.Include(c => c.Seferi).FirstOrDefault(filter);
            }
        }

        public List<Bilet> GetEntities(Expression<Func<Bilet, bool>> filter = null)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return filter == null
                    ? context.Tbl_Bilet.Include(c => c.Seferi).ToList()
                    : context.Tbl_Bilet.Include(c => c.Seferi).Where(filter).ToList();
            }
        }
    }
}