using ecommerce.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Data.Mapping
{
    public class ProvinceMapping : BaseMapping<ProvinceEntity>
    {
        public override void Configure(EntityTypeBuilder<ProvinceEntity> builder)
        {
            base.Configure(builder);

            // table 
            builder.ToTable("Provinces");
        }
    }
}
