using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductSmallTask.DOTS;
using ProductSmallTask.Models;
using ProductSmallTask.Repo;
using ProductSmallTask.Service;

namespace ProductSmallTask.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController:ControllerBase
    {
        private readonly  IProductServices servicesproduct;

        public ProductController(IProductServices context)
        {
            servicesproduct=context;

        }

        [AllowAnonymous]

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(ProductInputDTO product)
        {
            try
            {
                return Ok(servicesproduct.AddNewProduct(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts(int page, int PageSize)
        {
            try
            {
                return Ok(servicesproduct.GetAllProducts(page, PageSize));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetProductByID {ID}")]
        public IActionResult GetProductByID(int ID)
        {
            try
            {
                return Ok(servicesproduct.GetProductByID(ID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("UpdateProduct {ID}")]
        public IActionResult GetProductByID(int ID, ProductInputDTO product)
        {
            try
            {
                return Ok(servicesproduct.UpdateProduct(product, ID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteProduct {ID}")]
        public IActionResult DeleteProduct(int ID)
        {
            try
            {
                servicesproduct.DeleteProduct(ID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
