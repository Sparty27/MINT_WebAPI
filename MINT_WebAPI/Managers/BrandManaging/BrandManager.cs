using MINT_WebAPI.DataControllers;
using MINT_WebAPI.Models;

namespace MINT_WebAPI.Managers.BrandManaging
{
    public class BrandManager : IBrandManager
    {
        private readonly BrandsDataController _brandsDataController;

        public BrandManager(IConfiguration configuration)
        {
            _brandsDataController = new BrandsDataController(configuration);
        }

        public IEnumerable<Brand> GetAllBrands()
            => _brandsDataController.GetAllBrands();

        public Brand? GetBrandById(int id)
            => _brandsDataController.GetBrandById(id);

        public Brand? GetBrandByName(string name)
            => _brandsDataController.GetBrandByName(name);

        public int CreateBrand(Brand brand)
            => _brandsDataController.CreateBrand(brand);

        public int UpdateBrand(Brand brand)
            => _brandsDataController.UpdateBrand(brand);

        public int DeleteBrandById(int id)
            => _brandsDataController.DeleteBrandById(id);
    }
}
