using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.DbAccess.Abstract
{
    public interface ISorumluDal:IEntityRepository<Sorumlu>,IFilter<Sorumlu>
    {
    }
}
