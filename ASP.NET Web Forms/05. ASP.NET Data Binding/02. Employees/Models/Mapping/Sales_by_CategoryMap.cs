using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EmployeesDataBinding.Models.Mapping
{
    public class Sales_by_CategoryMap : EntityTypeConfiguration<Sales_by_Category>
    {
        public Sales_by_CategoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CategoryID, t.CategoryName, t.ProductName });

            // Properties
            this.Property(t => t.CategoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Sales by Category");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.ProductSales).HasColumnName("ProductSales");
        }
    }
}
