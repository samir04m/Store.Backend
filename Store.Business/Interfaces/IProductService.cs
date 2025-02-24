using Store.Business.DTOs;
using System.Threading.Tasks;

namespace Store.Business.Interfaces
{
    public interface IProductService
    {
        //Task<IEnumerable<ProductDto>> GetAllProducts(string searchTerm, int? categoryId, string sortBy, bool ascending);
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> AddProductAsync(ProductDto productDto);
        Task<ProductDto> UpdateProductAsync(ProductDto productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
