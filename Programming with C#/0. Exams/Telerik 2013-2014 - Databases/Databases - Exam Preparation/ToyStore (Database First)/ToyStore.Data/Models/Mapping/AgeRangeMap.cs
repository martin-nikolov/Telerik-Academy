namespace ToyStore.Data.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class AgeRangeMap : EntityTypeConfiguration<AgeRange>
    {
        public AgeRangeMap()
        {
            // Primary Key
            this.HasKey(t => t.AgeRangeId);

            // Properties
            // Table & Column Mappings
            this.ToTable("AgeRanges");
            this.Property(t => t.AgeRangeId).HasColumnName("AgeRangeId");
            this.Property(t => t.MinAge).HasColumnName("MinAge");
            this.Property(t => t.MaxAge).HasColumnName("MaxAge");
        }
    }
}