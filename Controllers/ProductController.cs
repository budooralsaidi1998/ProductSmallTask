using Microsoft.AspNetCore.Mvc;
using ProductSmallTask.DOTS;
using ProductSmallTask.Models;
using ProductSmallTask.Repo;
using ProductSmallTask.Service;

namespace ProductSmallTask.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController:ControllerBase
    {
        private readonly  IProductServices servicesproduct;

        public ProductController(IProductServices context)
        {
            servicesproduct=context;

        }



        //[HttpPost]
        //public IActionResult AddProduct([FromBody] ProductInputDTO productCreateDTO)
        //{
        //    // Check if the input DTO is null
        //    if (productCreateDTO == null)
        //    {
        //        return BadRequest("Product data is required.");
        //    }

        //    try
        //    {
        //        // Call the service to add the product and get the output DTO
        //        ProductOutputDTO createdProduct = servicesproduct.AddProduct(productCreateDTO);

        //        // Check if the product was successfully created
        //        if (createdProduct == null)
        //        {
        //            return BadRequest("The product could not be created.");
        //        }

        //        // Return the created product (Output DTO)
        //        return CreatedAtAction(nameof(), new { id = createdProduct.Id }, createdProduct);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        // Specific exception for validation issues (e.g., invalid product data)
        //        return BadRequest($"Invalid input: {ex.Message}");
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        // Handle any operation-related exceptions (like database-related issues)
        //        return BadRequest($"Operation failed: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Catch any other unexpected exceptions
        //        return StatusCode(StatusCodes.Status500InternalServerError, $"An unexpected error occurred: {ex.Message}");
        //    }
        //}

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductInputDTO productCreateDTO)
        {
            if (productCreateDTO == null)
            {
                return BadRequest("Product data is required.");
            }

            try
            {
                // Manually create a Product model from ProductInputDTO
                Product product = new Product
                {
                    Name = productCreateDTO.Name,
                    Price = productCreateDTO.Price,
                    Category = string.IsNullOrEmpty(productCreateDTO.Category) ? "general" : productCreateDTO.Category,  // Default to "general" if no category provided
                    DateAdded = DateTime.UtcNow // You can set the date when the product is added
                };

                // Call the service to add the product
                Product createdProduct = servicesproduct.AddProduct(product);

                if (createdProduct == null)
                {
                    return BadRequest("The product could not be created.");
                }

                // Map the created product to ProductOutputDTO (manual mapping)
                ProductOutputDTO createdProductDTO = new ProductOutputDTO
                {
                    Id = createdProduct.Id,
                    Name = createdProduct.Name,
                    Price = createdProduct.Price,
                    Category = createdProduct.Category,
                    DateAdded = createdProduct.DateAdded
                };

                // Return the created product (Output DTO)
                return CreatedAtAction(nameof(GetProductById), new { id = createdProductDTO.Id }, createdProductDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = servicesproduct.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
