namespace MINT_WebAPI.Constants
{
    public static class DatabaseConstants
    {
        #region Brand
        public const string GetAllBrands = "sp_Brands_GetAllBrands";
        public const string GetBrandById = "sp_Brands_GetBrandById";
        public const string GetBrandByName = "sp_Brands_GetBrandByName";
        public const string CreateBrand = "sp_Brands_CreateBrand";
        public const string UpdateBrand = "sp_Brands_UpdateBrand";
        public const string DeleteBrandById = "sp_Brands_DeleteBrandById";
        #endregion

        #region Category
        public const string GetAllCategories = "sp_Categories_GetAllCategories";
        public const string GetCategoryById = "sp_Categories_GetCategoryById";
        public const string GetCategoryByName = "sp_Categories_GetCategoryByName";
        public const string CreateCategory = "sp_Categories_CreateCategory";
        public const string UpdateCategory = "sp_Categories_UpdateCategory";
        public const string DeleteCategoryById = "sp_Categories_DeleteCategoryById";
        #endregion


    }
}
