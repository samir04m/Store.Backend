using Store.Data.Entities;
using System.Threading.Tasks;

namespace Store.Data.Interfaces
{
    public interface IProductRepository
    {
        //Task<IEnumerable<Product>> GetProducts(string search, int? categoryId, string orderBy, bool ascending, int page, int pageSize);
        //Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        //Task AddAsync(Product product);
        //Task UpdateAsync(Product product);
        //Task DeleteAsync(Product product);
    }
}
