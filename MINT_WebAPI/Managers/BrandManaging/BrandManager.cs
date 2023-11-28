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
    }
}
