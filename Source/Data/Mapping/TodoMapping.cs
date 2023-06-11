using ecommerce.Data.Entity;
using ecommerce.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Source.Data.Mapping
{
    public class TodoMapping : BaseMapping<TodoEntity>
    {
        public override void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            base.Configure(builder);

            // table 
            builder.ToTable("Todos");

            // relationship
            builder.HasOne(t => t.User).WithMany(u => u.Todos).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
