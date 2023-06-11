using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.DataModels.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWC.Infrastructure.Persistence.Configurations.Sales
{
    internal class SalesTerritoryConfig : IEntityTypeConfiguration<SalesTerritory>
    {
        public void Configure(EntityTypeBuilder<SalesTerritory> entity)
        {
            entity.ToTable("SalesTerritory", schema: "Sales");
            entity.HasKey(e => e.TerritoryID);
            entity.HasIndex(p => p.Name).IsUnique();
            entity.HasIndex(p => new { p.Name, p.CountryRegionCode }).IsUnique();
            entity.HasOne<CountryRegion>()
                .WithMany()
                .HasForeignKey(p => p.CountryRegionCode)
                .IsRequired();

            entity.Property(e => e.TerritoryID)
                .HasColumnName("TerritoryID")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar(50)");
            entity.Property(e => e.CountryRegionCode)
                .HasColumnName("CountryRegionCode")
                .HasColumnType("nvarchar(3)")
                .IsRequired();
            entity.Property(e => e.Group)
                .HasColumnName("Group")
                .HasColumnType("nvarchar(50)")
                .IsRequired();
            entity.Property(e => e.SalesYTD)
                .HasColumnName("SalesYTD")
                .HasColumnType("money")
                .IsRequired();
            entity.Property(e => e.SalesLastYear)
                .HasColumnName("SalesLastYear")
                .HasColumnType("money")
                .IsRequired();
            entity.Property(e => e.CostYTD)
                .HasColumnName("CostYTD")
                .HasColumnType("money")
                .IsRequired();
            entity.Property(e => e.CostLastYear)
                .HasColumnName("CostLastYear")
                .HasColumnType("money")
                .IsRequired();
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