using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EmployeesDataBinding.Models.Mapping
{
    public class Products_Above_Average_PriceMap : EntityTypeConfiguration<Products_Above_Average_Price>
    {
        public Products_Above_Average_PriceMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductName);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Products Above Average Price");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
        }
    }
}
