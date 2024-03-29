#pragma warning disable CS8604

using System.Reflection;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.DataModels.Sales;
using Microsoft.EntityFrameworkCore;

namespace AWC.Infrastructure.Persistence
{
    public sealed class AwcContext : DbContext
    {
        public AwcContext(DbContextOptions<AwcContext> options)
            : base(options)
        { }

        public DbSet<AddressType>? AddressType { get; set; }
        public DbSet<ContactType>? ContactType { get; set; }
        public DbSet<PhoneNumberType>? PhoneNumberType { get; set; }
        public DbSet<CountryRegion>? CountryRegion { get; set; }
        public DbSet<SalesTerritory>? SalesTerritory { get; set; }
        public DbSet<StateProvince>? StateProvince { get; set; }
        public DbSet<BusinessEntity>? BusinessEntity { get; set; }
        public DbSet<Company>? Company { get; set; }
        public DbSet<EmployeeDataModel>? Employee { get; set; }
        public DbSet<BusinessEntityAddress>? BusinessEntityAddress { get; set; }
        public DbSet<BusinessEntityContact>? BusinessEntityContact { get; set; }
        public DbSet<Address>? Address { get; set; }
        public DbSet<PersonDataModel>? Person { get; set; }
        public DbSet<EmailAddress>? EmailAddress { get; set; }
        public DbSet<PersonPhone>? PersonPhone { get; set; }
        public DbSet<Password>? Password { get; set; }
        public DbSet<Department>? Department { get; set; }
        public DbSet<Shift>? Shift { get; set; }
        public DbSet<EmployeeDepartmentHistory>? EmployeeDepartmentHistory { get; set; }
        public DbSet<EmployeePayHistory>? EmployeePayHistory { get; set; }
        public DbSet<EmployeeManager>? EmployeeManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.HasDbFunction(typeof(AwcContext).GetMethod(nameof(Get_Manager_ID), new[] { typeof(int) }));

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public int Get_Manager_ID(int employeeID)
            => throw new NotSupportedException();
    }
}