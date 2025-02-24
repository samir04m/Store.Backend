using Store.Business.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Business.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> AddProductAsync(ProductDto productDto);
        Task<ProductDto> UpdateProductAsync(ProductDto productDto);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductDto>> GetProductsAsync(string search, string sortBy, bool ascending);
    }
}
