using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Products_Order_Management.Models;
using Products_Order_Management.Models.DTOs;
using Products_Order_Management.Services.IServices;

namespace Products_Order_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProduct product, IMapper mapper)
        {
            _productService = product;
            _mapper = mapper;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAllProducts()
        {
            var allProducts = await _productService.GetAllProducts();
            return Ok(allProducts);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProductById(Guid id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product Not Found, \t YOU MIGHT WANT TO CONFIRM THE SEARCH INPUT YOU USED");
            }
            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult<string>> AddProduct(AddProductDTO newProduct)
        {
            var mappedProduct = _mapper.Map<Products>(newProduct);
            var response = await _productService.AddProduct(mappedProduct);
            return Created($" ", response);

        }

        //[HttpGet("{ProductId}")]
        //public async Task<ActionResult<List<Orders>>> GetOrdersMade(Guid ProductId)
        //{
        //    var orders = await _productService.GetOrdersMade(ProductId);
        //    if (orders==null)
        //    {
        //        return NotFound("No Orders have been made yet on this product");
        //    }
        //    return Ok(orders);

        //}
    }
}
