using ProductSmallTask.DOTS;
using ProductSmallTask.Models;

namespace ProductSmallTask.Repo
{
    public interface IProductRepo
    {
        int AddProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts(int page, int PageSize);
        Product GetProductById(int id);
        int GetProductId(string name);
        Product UpdateProduct(int id, ProductInputDTO product);
    }
}