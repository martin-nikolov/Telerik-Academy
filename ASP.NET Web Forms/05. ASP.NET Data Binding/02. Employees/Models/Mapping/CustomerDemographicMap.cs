using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EmployeesDataBinding.Models.Mapping
{
    public class CustomerDemographicMap : EntityTypeConfiguration<CustomerDemographic>
    {
        public CustomerDemographicMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerTypeID);

            // Properties
            this.Property(t => t.CustomerTypeID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("CustomerDemographics");
            this.Property(t => t.CustomerTypeID).HasColumnName("CustomerTypeID");
            this.Property(t => t.CustomerDesc).HasColumnName("CustomerDesc");

            // Relationships
            this.HasMany(t => t.Customers)
                .WithMany(t => t.CustomerDemographics)
                .Map(m =>
                    {
                        m.ToTable("CustomerCustomerDemo");
                        m.MapLeftKey("CustomerTypeID");
                        m.MapRightKey("CustomerID");
                    });


        }
    }
}
