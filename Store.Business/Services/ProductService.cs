using Store.Business.DTOs;
using Store.Business.Interfaces;
using Store.Data.Entities;
using Store.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                return ProductMapper.ToDto(product);
            }
            return default;
        }

        public async Task<ProductDto> AddProductAsync(ProductDto productDto)
        {
            Product product = ProductMapper.ToEntity(productDto);
            var newProduct = await _productRepository.AddAsync(product);
            var productCreated = await _productRepository.GetByIdAsync(newProduct.Id);
            return ProductMapper.ToDto(productCreated);
        }

        public async Task<ProductDto> UpdateProductAsync(ProductDto productDto)
        {
            var productEntity = ProductMapper.ToEntity(productDto);
            var updatedProduct = await _productRepository.UpdateAsync(productEntity);

            return updatedProduct != null 
                ? ProductMapper.ToDto(updatedProduct) 
                : null;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(string search, string sortBy, bool ascending)
        {
            var products = await _productRepository.GetProductsAsync(search, sortBy, ascending);
            return products.Select(p => ProductMapper.ToDto(p));
        }
    }
}
