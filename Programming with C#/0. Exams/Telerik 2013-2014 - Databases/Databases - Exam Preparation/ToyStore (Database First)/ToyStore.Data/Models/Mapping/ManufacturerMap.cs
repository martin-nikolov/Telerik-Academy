namespace ToyStore.Data.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class ManufacturerMap : EntityTypeConfiguration<Manufacturer>
    {
        public ManufacturerMap()
        {
            // Primary Key
            this.HasKey(t => t.ManufacturerId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Manufacturers");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Country).HasColumnName("Country");
        }
    }
}