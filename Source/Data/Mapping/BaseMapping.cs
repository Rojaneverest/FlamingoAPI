using ecommerce.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Data.Mapping
{
    public class BaseMapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {

       public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // key
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnType("nvarchar(450)");

            // fields
            builder.Property(b => b.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(b => b.UpdatedAt).HasDefaultValue(DateTime.Now);
        }
    }
}
