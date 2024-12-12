using ProductSmallTask.DOTS;
using ProductSmallTask.Models;
using ProductSmallTask.Repo;

namespace ProductSmallTask.Service
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepo _repo;

        public ProductServices(IProductRepo context)
        {
            _repo = context;

        }

        public void AddProduct(Product product)
        {
            try
            {
                // Validate product name 
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    throw new ArgumentException("Product name is required.");
                }

                // Validate price (must be greater than 0)
                if (product.Price <= 0)
                {
                    throw new ArgumentException("Product price must be greater than 0.");
                }

                // Set default category if not provided
                if (string.IsNullOrWhiteSpace(product.Category))
                {
                    product.Category = "general";
                }
                 if(product.DateAdded != DateTime.MinValue) 
                    {
                        product.DateAdded = DateTime.MinValue;
                    }

                // Add the product to the database
                _repo.AddProduct(product);
               
            }


            catch (ArgumentException ex)
            {
                // Handle specific validation exceptions
                throw new InvalidOperationException($"Validation error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                throw new InvalidOperationException("An error occurred while adding the product.", ex);
            }
        }

        public void AddNewProduct(ProductInputDTO product)
        {
            var CompleteProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = DateTime.Now,
            };
             _repo.AddProduct(CompleteProduct);
        }


        public List<ProductOutputDTO> GetProducts()
        {
            var ListofProducts = new List<ProductOutputDTO>();
            foreach (Product product in _repo.GetAllProducts())
            {
                var p = ConvertToOutputDTO(product);
                ListofProducts.Add(p);
            }
            return ListofProducts;
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
            string ID =_repo.GetById(productDTO);
            var p = new Product
            {
                PID = ID,
                Name = productDTO.Name,
                Price = productDTO.Price,
                Category = productDTO.Category,
                DateAdded = DateTime.Now,
            };
            return p;
        }
        public Product GetById(int id)
        {
            try
            {
                // Validate the ID
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid product ID.");
                }

                // Get the product from the repository
                var product = _repo.GetById(id);

                if (product == null)
                {
                    throw new KeyNotFoundException("Product not found.");
                }

                return product;
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException($"Validation error: {ex.Message}", ex);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException($"Error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the product.", ex);
            }
        }


        // Get all products
        public List<Product> GetAllProducts()
        {
            try
            {
                // Get the list of products
                var products = _repo.GetAllProducts();

                if (products == null || products.Count == 0)
                {
                    throw new InvalidOperationException("No products found.");
                }

                return products;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the products.", ex);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                // Validate the product before updating
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    throw new ArgumentException("Product name is required.");
                }

                if (product.Price <= 0)
                {
                    throw new ArgumentException("Product price must be greater than 0.");
                }

                if (product.Id <= 0)
                {
                    throw new ArgumentException("Invalid product ID.");
                }

                // Get the existing product from the repository
                var existingProduct = _repo.GetById(product.Id);
                if (existingProduct == null)
                {
                    throw new KeyNotFoundException("Product not found.");
                }

                // Update the product fields
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category ?? "general"; // Default to "general" if Category is null
                existingProduct.DateAdded = product.DateAdded;

                // Save the updated product
                _repo.UpdateProduct(existingProduct);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException($"Validation error: {ex.Message}", ex);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException($"Error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while updating the product.", ex);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                // Validate the product ID
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid product ID.");
                }

                // Check if the product exists in the repository
                var product = _repo.GetById(id);
                if (product == null)
                {
                    throw new KeyNotFoundException("Product not found.");
                }

                // Delete the product from the repository
                _repo.DeleteProduct(id);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException($"Validation error: {ex.Message}", ex);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException($"Error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while deleting the product.", ex);
            }
        }
    }
}
