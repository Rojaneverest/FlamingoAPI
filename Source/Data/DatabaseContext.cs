using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ecommerce.Data.Entity;
using ecommerce.Data.Mapping;

namespace ecommerce.Data
{
    public class DatabaseContext : IdentityDbContext<UserEntity>
    {
        public DbSet<ProvinceEntity> Provinces { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ApplyConfigurations(builder);
            base.OnModelCreating(builder);
        }

        private static void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => !string.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.GetInterfaces().Any(i =>
            //        i.IsGenericType && i.GetGenericTypeDefinition() == typeof(BaseMapping<>)))
            //    .ToList();

            //foreach (var type in typesToRegister)
            //{
            //    dynamic? configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.ApplyConfiguration(configurationInstance);
            //}
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ProvinceMapping());
        }

    }
}
