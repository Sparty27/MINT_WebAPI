using MINT_WebAPI.Models;

namespace MINT_WebAPI.Managers.BrandManaging
{
    public interface IBrandManager
    {
        IEnumerable<Brand> GetAllBrands();
        Brand? GetBrandById(int id);

        Brand? GetBrandByName(string name);
        int CreateBrand(Brand brand);

        int UpdateBrand(Brand brand);

        int DeleteBrandById(int id);
    }
}
