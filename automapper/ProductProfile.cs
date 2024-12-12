using AutoMapper;
using ProductSmallTask.DOTS;
using ProductSmallTask.Models;

namespace ProductSmallTask.automapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            // Map ProductCreateDTO to Product entity (used when creating a product)
            CreateMap<ProductInputDTO, Product>();

            // Map Product entity to ProductOutputDTO (used when returning the created product)
            CreateMap<Product, ProductOutputDTO>();
        }
    }
}
