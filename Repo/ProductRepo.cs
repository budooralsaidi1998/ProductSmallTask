using ProductSmallTask.DOTS;
using ProductSmallTask.Models;
using System.Collections.Specialized;

namespace ProductSmallTask.Repo
{
    public class ProductRepo : IProductRepo
    {

        private readonly ApplicationDbContexr _context;

        public ProductRepo(ApplicationDbContexr context)
        {
            _context = context;
        }


        public IEnumerable<Product> GetAllProducts(int page, int PageSize)
        {
            int size = PageSize;
            int number = PageSize * page;
            return _context.products.OrderByDescending(p => p.DateAdded).Skip(number).Take(PageSize).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.products.FirstOrDefault(p => p.Id == id);
        }

        public int GetProductId(string name)
        {
            var product = _context.products.FirstOrDefault(p => p.Name == name);
            return product.Id;
        }

        public int AddProduct(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }
        }

        public Product UpdateProduct(int id, ProductInputDTO product)
        {
            var currentProduct = GetProductById(id);
            if (currentProduct != null)
            {
                currentProduct.Name = product.Name;
                currentProduct.Price = product.Price;
                currentProduct.Category = product.Category;

                _context.products.Update(currentProduct);
                _context.SaveChanges();

            }
            return currentProduct;
        }
    }
}
