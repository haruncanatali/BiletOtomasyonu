using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiletOtomasyonu.Models;

namespace BiletOtomasyonu.DbAccess.Abstract
{
    public interface IMusteriDal:IEntityRepository<Musteri>,IFilter<Musteri>
    {
    }
}
