namespace ToyStore.Data.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class ToyMap : EntityTypeConfiguration<Toy>
    {
        public ToyMap()
        {
            // Primary Key
            this.HasKey(t => t.ToyId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            this.Property(t => t.Color)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Toys");
            this.Property(t => t.ToyId).HasColumnName("ToyId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.AgeRangeId).HasColumnName("AgeRangeId");

            // Relationships
            this.HasOptional(t => t.AgeRange)
                .WithMany(t => t.Toys)
                .HasForeignKey(d => d.AgeRangeId);
            this.HasRequired(t => t.Manufacturer)
                .WithMany(t => t.Toys)
                .HasForeignKey(d => d.ManufacturerId);
        }
    }
}