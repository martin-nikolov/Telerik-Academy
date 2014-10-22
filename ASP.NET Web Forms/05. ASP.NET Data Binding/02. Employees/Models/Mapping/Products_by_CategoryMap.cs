using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EmployeesDataBinding.Models.Mapping
{
    public class Products_by_CategoryMap : EntityTypeConfiguration<Products_by_Category>
    {
        public Products_by_CategoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CategoryName, t.ProductName, t.Discontinued });

            // Properties
            this.Property(t => t.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.QuantityPerUnit)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Products by Category");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            this.Property(t => t.UnitsInStock).HasColumnName("UnitsInStock");
            this.Property(t => t.Discontinued).HasColumnName("Discontinued");
        }
    }
}
