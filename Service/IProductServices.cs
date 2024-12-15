using ProductSmallTask.DOTS;
using ProductSmallTask.Models;

namespace ProductSmallTask.Service
{
    public interface IProductServices
    {
        int AddNewProduct(ProductInputDTO product);
        ProductOutputDTO ConvertToOutputDTO(Product product);
        Product ConvertToProduct(ProductInputDTO productDTO);
        void DeleteProduct(int ID);
        List<ProductOutputDTO> GetAllProducts(int page, int PageSize);
        ProductOutputDTO GetProductByID(int id);
        ProductOutputDTO UpdateProduct(ProductInputDTO product, int ID);
    }
}