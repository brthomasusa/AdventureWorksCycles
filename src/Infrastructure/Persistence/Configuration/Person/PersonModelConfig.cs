using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWC.Infrastructure.Persistence.Configurations.Person
{
    internal class PersonModelConfig : IEntityTypeConfiguration<PersonDataModel>
    {
        public void Configure(EntityTypeBuilder<PersonDataModel> entity)
        {
            entity.ToTable("Person", schema: "Person");
            entity.HasKey(e => e.BusinessEntityID);

            entity.HasOne(p => p.Employee)
                .WithOne()
                .HasForeignKey<EmployeeDataModel>(p => p.BusinessEntityID)
                .IsRequired();
            entity.HasMany(p => p.EmailAddresses)
                .WithOne()
                .HasForeignKey(p => p.BusinessEntityID);
            entity.HasMany(p => p.Telephones)
                .WithOne()
                .HasForeignKey(p => p.BusinessEntityID);
            entity.HasMany(p => p.BusinessEntityAddresses)
                .WithOne()
                .HasForeignKey(p => p.BusinessEntityID);

            entity.Property(e => e.BusinessEntityID)
                .HasColumnName("BusinessEntityID")
                .ValueGeneratedNever();
            entity.Property(e => e.PersonType)
                .IsRequired()
                .HasColumnName("PersonType")
                .HasColumnType("nchar(2)");
            entity.Property(e => e.NameStyle)
                .HasColumnName("NameStyle")
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValue(0);
            entity.Property(e => e.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar(8)");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar(50)");
            entity.Property(e => e.MiddleName)
                .HasColumnName("MiddleName")
                .HasColumnType("nvarchar(50)");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("nvarchar(50)");
            entity.Property(e => e.Suffix)
                .HasColumnName("Suffix")
                .HasColumnType("nvarchar(8)");
            entity.Property(e => e.EmailPromotion)
                .HasColumnName("EmailPromotion")
                .HasColumnType("int")
                .IsRequired()
                .HasDefaultValue(0);
            entity.Property(e => e.RowGuid)
                .HasColumnName("rowguid")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired()
                .HasDefaultValue(Guid.NewGuid());
            entity.Property(e => e.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);
        }
    }
}