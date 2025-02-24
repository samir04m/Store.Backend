using Store.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Store.Data.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");

            HasKey(c => c.Id);

            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Category_Name") { IsUnique = true }));

            HasMany(c => c.Products)
                .WithRequired(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
