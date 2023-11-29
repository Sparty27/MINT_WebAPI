using MINT_WebAPI.DataControllers;
using MINT_WebAPI.Models;

namespace MINT_WebAPI.Managers.ProductManaging
{
    public class ProductManager : IProductManager
    {
        private readonly ProductsDataController _productsDataController;

        public ProductManager(IConfiguration configuration)
        {
            _productsDataController = new ProductsDataController(configuration);
        }

        public IEnumerable<Product> GetAllProducts()
            => _productsDataController.GetAllProducts();

        public Product? GetProductById(int id)
            => _productsDataController.GetProductById(id);

        public Product? GetProductByName(string name)
            => _productsDataController.GetProductByName(name);

        public int CreateProduct(Product product)
            => _productsDataController.CreateProduct(product);

        public int UpdateProduct(Product product)
            => _productsDataController.UpdateProduct(product);

        public int DeleteProductById(int id)
            => _productsDataController.DeleteProductById(id);
    }
}
