namespace ToyStore.Data.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Categories");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasMany(t => t.Toys)
                .WithMany(t => t.Categories)
                .Map(m =>
                {
                    m.ToTable("ToysCategories");
                    m.MapLeftKey("CategoryId");
                    m.MapRightKey("ToyId");
                });
        }
    }
}