using MINT_WebAPI.Models;

namespace MINT_WebAPI.Managers.ProductManaging
{
    public interface IProductManager
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);

        Product? GetProductByName(string name);
        int CreateProduct(Product product);

        int UpdateProduct(Product product);

        int DeleteProductById(int id);
    }
}
