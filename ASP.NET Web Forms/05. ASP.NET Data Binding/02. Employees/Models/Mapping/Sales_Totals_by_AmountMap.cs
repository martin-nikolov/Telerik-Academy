using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EmployeesDataBinding.Models.Mapping
{
    public class Sales_Totals_by_AmountMap : EntityTypeConfiguration<Sales_Totals_by_Amount>
    {
        public Sales_Totals_by_AmountMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OrderID, t.CompanyName });

            // Properties
            this.Property(t => t.OrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Sales Totals by Amount");
            this.Property(t => t.SaleAmount).HasColumnName("SaleAmount");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.ShippedDate).HasColumnName("ShippedDate");
        }
    }
}
