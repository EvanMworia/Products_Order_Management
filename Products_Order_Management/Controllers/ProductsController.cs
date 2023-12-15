using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_Order_Management.Data;
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
        private readonly DataContext _context;
        public ProductsController(IProduct product, IMapper mapper, DataContext context)
        {
            _productService = product;
            _mapper = mapper;
            _context = context;
            
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




        // endpoint for filtering by product name

        [HttpGet("filter-by-name")]
        public async Task<ActionResult<List<Products>>> GetProductsByName([FromQuery] string productName)
        {
            try
            {
                // Validate and sanitize input values
                if (string.IsNullOrWhiteSpace(productName))
                {
                    return BadRequest("Product name is required.");
                }

                // Perform filtering by product name
                var filteredProducts = await _context.Products
                    .Where(p => p.Name.Contains(productName, StringComparison.OrdinalIgnoreCase))
                    .ToListAsync();

                return Ok(filteredProducts);
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        //Filtering by name and price
        [HttpGet("filter-by-name-and-price")]
        public async Task<ActionResult<List<Products>>> GetProductsByNameAndPrice([FromQuery] string productName, [FromQuery] decimal price)
        {
            try
            {
                // Validate and sanitize input values
                if (string.IsNullOrWhiteSpace(productName))
                {
                    return BadRequest("Product name is required.");
                }

                // Perform filtering by product name and price
                var filteredProducts = await _context.Products
                    .Where(p => p.Name.Contains(productName, StringComparison.OrdinalIgnoreCase) && p.Price == price)
                    .ToListAsync();

                return Ok(filteredProducts);
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
