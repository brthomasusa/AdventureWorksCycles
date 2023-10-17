using AWC.Infrastructure.Persistence.DataModels.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWC.Infrastructure.Persistence.Configurations.Person
{
    internal class ContactTypeConfig : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> entity)
        {
            entity.ToTable("ContactType", schema: "Person");
            entity.HasKey(e => e.ContactTypeID);
            entity.HasIndex(p => p.Name).IsUnique();

            entity.Property(e => e.ContactTypeID)
                .HasColumnName("ContactTypeID")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar(50)");
            entity.Property(e => e.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);
        }
    }
}