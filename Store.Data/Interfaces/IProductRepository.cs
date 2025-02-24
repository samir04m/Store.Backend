using Store.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync(string search, string sortBy, bool ascending);
    }
}
