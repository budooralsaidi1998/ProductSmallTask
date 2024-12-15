using ProductSmallTask.DOTS;
using ProductSmallTask.Models;
using ProductSmallTask.Repo;
using System.Xml.Serialization;

namespace ProductSmallTask.Service
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepo _repo;

        public ProductServices(IProductRepo context)
        {
            _repo = context;

        }

        public int AddNewProduct(ProductInputDTO product)
        {

            var CompleteProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = DateTime.Now,
            };

            return _repo.AddProduct(CompleteProduct);
        }


        public List<ProductOutputDTO> GetAllProducts(int page, int PageSize)
        {
            var ListofProducts = new List<ProductOutputDTO>();
            foreach (Product product in _repo.GetAllProducts(page, PageSize))
            {
                var p = ConvertToOutputDTO(product);

                ListofProducts.Add(p);
            }
            return ListofProducts;
        }


        public ProductOutputDTO GetProductByID(int id)
        {
            var product = _repo.GetProductById(id);

            //Mapping the product (Product to DTO)
            var p = new ProductOutputDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = product.DateAdded,
            };

            return p;
        }


        public ProductOutputDTO UpdateProduct(ProductInputDTO product, int ID)
        {
            var updatedProduct = _repo.UpdateProduct(ID, product);

            return ConvertToOutputDTO(updatedProduct);
        }

        public void DeleteProduct(int ID)
        {
            _repo.DeleteProduct(ID);
        }


        public ProductOutputDTO ConvertToOutputDTO(Product product)
        {
            var p = new ProductOutputDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = DateTime.Now,
            };
            return p;
        }


        public Product ConvertToProduct(ProductInputDTO productDTO)
        {
            int ID = _repo.GetProductId(productDTO.Name);
            var p = new Product
            {
                Id = ID,
                Name = productDTO.Name,
                Price = productDTO.Price,
                Category = productDTO.Category,
                DateAdded = DateTime.Now,
            };
            return p;
        }
    }
}
