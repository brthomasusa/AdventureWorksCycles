#pragma warning disable CS8604

using System.Reflection;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using Microsoft.EntityFrameworkCore;

namespace AWC.Infrastructure.Persistence
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions<EfCoreContext> options)
            : base(options)
        { }

        public DbSet<Company>? Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.HasDbFunction(typeof(EfCoreContext).GetMethod(nameof(Get_Manager_ID), new[] { typeof(int) }));

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public int Get_Manager_ID(int employeeID)
            => throw new NotSupportedException();
    }
}