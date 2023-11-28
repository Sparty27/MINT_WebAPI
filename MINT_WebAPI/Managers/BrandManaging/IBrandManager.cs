using MINT_WebAPI.Models;

namespace MINT_WebAPI.Managers.BrandManaging
{
    public interface IBrandManager
    {
        IEnumerable<Brand> GetAllBrands();
    }
}
