using Store.Business.Interfaces;
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
        public async Task<IHttpActionResult> GetProductsAsync(int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }
    }
}