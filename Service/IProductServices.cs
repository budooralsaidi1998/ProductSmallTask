using ProductSmallTask.Models;

namespace ProductSmallTask.Service
{
    public interface IProductServices
    {
        void AddProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetById(int id);
        void UpdateProduct(Product product);
    }
}