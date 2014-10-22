using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EmployeesDataBinding.Models.Mapping
{
    public class Category_Sales_for_1997Map : EntityTypeConfiguration<Category_Sales_for_1997>
    {
        public Category_Sales_for_1997Map()
        {
            // Primary Key
            this.HasKey(t => t.CategoryName);

            // Properties
            this.Property(t => t.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Category Sales for 1997");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.CategorySales).HasColumnName("CategorySales");
        }
    }
}
