using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWC.Infrastructure.Persistence.Configuration.HumanResources
{
    internal class EmployeeManagerConfig : IEntityTypeConfiguration<EmployeeManager>
    {
        public void Configure(EntityTypeBuilder<EmployeeManager> entity)
        {
            entity.ToView("vGetManagersBasicInfo", schema: "HumanResources");
            entity.HasNoKey();

            entity.Property(e => e.BusinessEntityID)
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.DepartmentID)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasColumnName("DepartmentName");
            entity.Property(e => e.FirstName)
                .HasColumnName("FirstName");
            entity.Property(e => e.MiddleName)
                .HasColumnName("MiddleName");
            entity.Property(e => e.LastName)
                .HasColumnName("LastName");
        }
    }
}