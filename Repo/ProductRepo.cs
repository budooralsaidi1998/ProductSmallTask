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


        public void AddProduct(Product product)
        {
            try
            {
                // Add the product to the DbSet
                _context.products.Add(product);

                // Save changes to the database
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new InvalidOperationException("An error occurred while adding the product.", ex);
            }
        }

        // Method to get a product by its ID
        public Product GetById(int id)
        {
            try
            {
                return _context.products.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        // Method to get all products
        public List<Product> GetAllProducts()
        {
            try
            {


                return _context.products.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);

            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                // Find the product to update
                //var existingProduct = _context.products.FirstOrDefault(p => p.Id == product.Id);

                //if (existingProduct == null)
                //{
                //    throw new KeyNotFoundException("Product not found.");
                //}

                //// Update the existing product's properties
                //existingProduct.Name = product.Name;
                //existingProduct.Price = product.Price;
                //existingProduct.Category = product.Category ?? "general"; // Default to "general" if Category is null
                //existingProduct.DateAdded = product.DateAdded;

                _context.products.Update(product);
                // Save the changes to the database
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while updating the product.", ex);
            }
        }

        // Delete a product from the database by its ID
        public void DeleteProduct(int id)
        {
            try
            {
                // Find the product to delete
                var productToDelete = _context.products.FirstOrDefault(p => p.Id == id);

                if (productToDelete == null)
                {
                    throw new KeyNotFoundException("Product not found.");
                }

                // Remove the product from the DbSet
                _context.products.Remove(productToDelete);

                // Save the changes to the database
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while deleting the product.", ex);
            }
        }


    }
}
