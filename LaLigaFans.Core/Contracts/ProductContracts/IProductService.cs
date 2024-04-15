using LaLigaFans.Core.Enums;
using LaLigaFans.Core.Models.Products;

namespace LaLigaFans.Core.Contracts.ProductContracts
{
    public interface IProductService
    {
        Task<ProductsQueryServiceModel> AllAsync(
            string userId,
            string? category = null,
            string? team = null,
            string? searchTerm = null,
            ProductSorting sorting = ProductSorting.Newest,
            int currentPage = 1,
            int newsPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<bool> ExistAsync(int id);

        Task<ProductDetailsServiceModel> ProductDetailsByIdAsync(int id);

        Task<ProductsQueryServiceModel> FavoritesAsync(
            string userId,
            int currentPage = 1,
            int newsPerPage = 1);

        Task AddProductToFavoritesAsync(int productId, string userId);

        Task RemoveProductFromFavoritesAsync(int productId, string userId);

        Task<bool> IsFavoriteOfUserWithIdAsync(int productId, string userId);

        Task<IEnumerable<ProductCategory>> GetCategoriesAsync();

        Task<int> CreateAsync(ProductAddFormModel model);

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<ProductEditFormModel?> GetProductEditFormModelByIdAsync(int productId);

        Task EditAsync(int productId, ProductEditFormModel model);
    }
}
