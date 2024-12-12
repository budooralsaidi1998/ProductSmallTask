using ProductSmallTask.Models;

namespace ProductSmallTask.Repo
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetById(int id);
        void UpdateProduct(Product product);
    }
}