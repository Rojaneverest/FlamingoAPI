using ecommerce.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            // table
            builder.ToTable("AspNetUsers");

            // fields
            builder.Property(b => b.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(b => b.UpdatedAt).HasDefaultValue(DateTime.Now);

            // relationship
            builder.HasOne(u => u.Province)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProvinceId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
