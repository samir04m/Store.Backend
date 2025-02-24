using Store.Data.Entities;

namespace Store.Business.DTOs
{
    public static class ProductMapper
    {
        public static Product ToEntity(ProductDto dto)
        {
            if (dto == null) return null;

            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId
            };
        }

        public static ProductDto ToDto(Product entity)
        {
            if (entity == null) return null;

            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                CategoryId = entity.CategoryId,
                CategoryName = entity.Category?.Name
            };
        }
    }
}
