using Store.Business.DTOs;
using Store.Business.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Store.API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                return Content(HttpStatusCode.NotFound, "No existe el producto solicitado.");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("El producto enviado no es válido.");
            }

            try
            {
                var product = await _productService.AddProductAsync(productDto);
                return Ok(product);
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.");
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest("Los datos del producto no pueden ser nulos.");

            if (id != productDto.Id)
                return BadRequest("El ID del producto no coincide con el ID en la URL.");

            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(productDto);
                if (updatedProduct != null)
                {
                    return Ok(updatedProduct);
                }
                return Content(HttpStatusCode.NotFound, "No existe el producto indicado.");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.");
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            try
            {
                var deleted = await _productService.DeleteProductAsync(id);
                if (deleted)
                {
                    return Ok($"El producto fue eliminado correctamente.");
                }
                return Content(HttpStatusCode.NotFound, "No existe el producto indicado.");
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.");
            }
        }


    }
}