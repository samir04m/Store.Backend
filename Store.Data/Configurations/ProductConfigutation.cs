using Store.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Store.Data.Configurations
{
    public class ProductConfigutation : EntityTypeConfiguration<Product>
    {
        public ProductConfigutation()
        {
            ToTable("Products");

            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Product_Name")));

            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Product_Description")));

            Property(p => p.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            Property(p => p.CategoryId)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Product_CategoryId")));

            HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
