using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.DbAccess.Abstract
{
    public interface IFilter<TEntity> where TEntity:class,IEntity,new()
    {
        TEntity GetEntity(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter = null);
    }
}
