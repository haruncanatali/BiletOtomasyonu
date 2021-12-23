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
    public class OtobusDal:EntityRepositoryBase<Otobus,ProjeDbContext>,IOtobusDal
    {
        public Otobus GetEntity(Expression<Func<Otobus, bool>> filter)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return context.Tbl_Otobus.Include(c => c.Seferleri).Include(c=>c.Suruculeri).FirstOrDefault(filter);
            }
        }

        public List<Otobus> GetEntities(Expression<Func<Otobus, bool>> filter = null)
        {
            using (ProjeDbContext context = new ProjeDbContext())
            {
                return filter == null
                    ? context.Tbl_Otobus.Include(c => c.Seferleri).Include(c=>c.Suruculeri).ToList()
                    : context.Tbl_Otobus.Include(c => c.Seferleri).Include(c=>c.Suruculeri).Where(filter).ToList();
            }
        }
    }
}