using Store.Business.DTOs;
using Store.Business.Interfaces;
using Store.Data.Entities;
using Store.Data.Interfaces;
using System;
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
    }
}
