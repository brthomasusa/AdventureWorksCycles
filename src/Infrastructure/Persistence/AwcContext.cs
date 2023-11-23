#pragma warning disable CS8604

using System.Reflection;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.DataModels.Sales;
using Microsoft.EntityFrameworkCore;

namespace AWC.Infrastructure.Persistence
{
    public class AwcContext : DbContext
    {
        public AwcContext() { }

        public AwcContext(DbContextOptions<AwcContext> options)
            : base(options)
        { }

        public virtual DbSet<AddressType>? AddressType { get; set; }
        public virtual DbSet<ContactType>? ContactType { get; set; }
        public virtual DbSet<PhoneNumberType>? PhoneNumberType { get; set; }
        public virtual DbSet<CountryRegion>? CountryRegion { get; set; }
        public virtual DbSet<SalesTerritory>? SalesTerritory { get; set; }
        public virtual DbSet<StateProvince>? StateProvince { get; set; }
        public virtual DbSet<BusinessEntity>? BusinessEntity { get; set; }
        public virtual DbSet<Company>? Company { get; set; }
        public virtual DbSet<EmployeeDataModel>? Employee { get; set; }
        public virtual DbSet<BusinessEntityAddress>? BusinessEntityAddress { get; set; }
        public virtual DbSet<BusinessEntityContact>? BusinessEntityContact { get; set; }
        public virtual DbSet<Address>? Address { get; set; }
        public virtual DbSet<PersonDataModel>? Person { get; set; }
        public virtual DbSet<EmailAddress>? EmailAddress { get; set; }
        public virtual DbSet<PersonPhone>? PersonPhone { get; set; }
        public virtual DbSet<Password>? Password { get; set; }
        public virtual DbSet<Department>? Department { get; set; }
        public virtual DbSet<Shift>? Shift { get; set; }
        public virtual DbSet<EmployeeDepartmentHistory>? EmployeeDepartmentHistory { get; set; }
        public virtual DbSet<EmployeePayHistory>? EmployeePayHistory { get; set; }
        public virtual DbSet<EmployeeManager>? EmployeeManagers { get; set; }

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