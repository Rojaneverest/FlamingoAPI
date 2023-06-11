using ecommerce.Data;
using ecommerce.Data.Entity;
using ecommerce.Core.Base;

namespace ecommerce.Core.Province
{
    public class ProvinceDao : BaseDao<ProvinceEntity>
    {
        public ProvinceDao(DatabaseContext context) : base(context)
        {
        }
    }
}
