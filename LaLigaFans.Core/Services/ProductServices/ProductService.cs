using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Contracts.ProductContracts;
using LaLigaFans.Core.Enums;
using LaLigaFans.Core.Models.Products;
using LaLigaFans.Core.Models.Team;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace LaLigaFans.Core.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IRepository repository;

        private readonly IUploadService uploadService;

        public ProductService(
            IRepository _repository, 
            IUploadService _uploadService)
        {
            repository = _repository;
            uploadService = _uploadService;
        }

        public async Task<ProductsQueryServiceModel> AllAsync(
            string userId,
            string? category = null,
            string? team = null,
            string? searchTerm = null,
            ProductSorting sorting = ProductSorting.Newest,
            int currentPage = 1,
            int productsPerPage = 1)
        {
            var productsQuery = repository.AllReadOnly<Product>();

            if (!string.IsNullOrEmpty(category))
            {
                productsQuery = productsQuery
                    .Where(p => p.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(team))
            {
                productsQuery = productsQuery
                    .Where(p => p.Team.Name == team);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                productsQuery = productsQuery
                    .Where(p => 
                        p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                        p.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            productsQuery = sorting switch
            {
                ProductSorting.Oldest => productsQuery
                    .OrderBy(p => p.Id),
                ProductSorting.PriceLowToHigh => productsQuery
                    .OrderBy(p => p.Price),
                ProductSorting.PriceHighToLow => productsQuery
                    .OrderByDescending(p => p.Price),
                ProductSorting.FollowedTeams => productsQuery
                    .OrderBy(p => p.Team.Followers.Any(ut => ut.ApplicationUserId == userId) == false),
                _ => productsQuery
                    .OrderByDescending(p => p.Id)
            };

            var products = await productsQuery
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new ProductServiceModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageURL
                })
                .ToListAsync();

            var totalProducts = await productsQuery.CountAsync();

            var productsAndCount = new ProductsQueryServiceModel()
            {
                TotalProductCount = totalProducts,
                Products = products,
            };

            return productsAndCount;
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            var allCategoriesNames = await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();

            return allCategoriesNames;
        }

        public async Task<bool> ExistAsync(int id)
        {
            var result = await repository.AllReadOnly<Product>()
                .AnyAsync(p => p.Id == id);

            return result;
        }

        public async Task<ProductDetailsServiceModel> ProductDetailsByIdAsync(int id)
        {
            var productWithDetails = await repository.AllReadOnly<Product>()
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsServiceModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageURL,
                    Price = p.Price,
                    UnitsAvailable = p.UnitsAvailable
                })
                .FirstAsync();

            return productWithDetails;
        }


        public async Task<ProductsQueryServiceModel> FavoritesAsync(
            string userId,
            int currentPage = 1,
            int productsPerPage = 1)
        {
            var products = await repository.AllReadOnly<Product>()
                .Where(p => p.UsersFavorite.Any(uf => uf.ApplicationUserId == userId))
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new ProductServiceModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageURL
                })
                .ToListAsync();

            var totalProducts = await repository.AllReadOnly<Product>()
                .Where(p => p.CartsProducts.Any(cp => cp.Cart.ApplicationUserId == userId))
                .CountAsync();

            var productsAndCount = new ProductsQueryServiceModel()
            {
                TotalProductCount = totalProducts,
                Products = products,
            };

            return productsAndCount;


        }


        public async Task AddProductToFavoritesAsync(int productId, string userId)
        {
            var user = await repository.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.FavoriteProducts)
                .FirstOrDefaultAsync();

            if(user != null)
            {
                var appUserProduct = new ApplicationUserProduct()
                {
                    ProductId = productId,
                };

                user.FavoriteProducts.Add(appUserProduct);
                await repository.SaveChangesAsync();
            }
        }

        public async Task RemoveProductFromFavoritesAsync(int productId, string userId)
        {
            var user = await repository.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.FavoriteProducts)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                var removeProduct = user.FavoriteProducts
                    .Where(up => up.ProductId == productId)
                    .FirstOrDefault();
                if (removeProduct != null)
                {
                    user.FavoriteProducts.Remove(removeProduct);
                    await repository.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> IsFavoriteOfUserWithIdAsync(int productId, string userId)
        {
            bool result = false;
            var product = await repository.AllReadOnly<Product>()
                .Where(p => p.Id == productId)
                .Include(p => p.UsersFavorite)
                .FirstOrDefaultAsync();

            if(product != null)
            {
                result = product.UsersFavorite.Any(uf => uf.ApplicationUserId == userId);
            }

            return result;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new ProductCategory()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<int> CreateAsync(ProductAddFormModel model)
        {
            string imageUrl = model.Image.FileName;
            string folderName = "products";
            if (!await uploadService.UploadImage(model.Image, folderName))
            {
                imageUrl = "Default.png";
            }
            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                UnitsAvailable = model.UnitsAvailable,
                TeamId = model.TeamId,
                CategoryId = model.CategoryId,
                ImageURL = imageUrl
            };

            await repository.AddAsync(product);
            await repository.SaveChangesAsync();

            return product.Id;
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            var result = await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);

            return result;
        }

        public async Task<ProductEditFormModel?> GetProductEditFormModelByIdAsync(int productId)
        {
            var productModel = await repository.AllReadOnly<Product>()
                .Where(p => p.Id == productId)
                .Select(p => new ProductEditFormModel()
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    UnitsAvailable = p.UnitsAvailable,
                    CategoryId = p.CategoryId,
                    TeamId = p.TeamId
                })
                .FirstOrDefaultAsync();

            return productModel;
        }

        public async Task EditAsync(int productId, ProductEditFormModel model)
        {
            var product = await repository.GetByIdAsync<Product>(productId);

            if(product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.UnitsAvailable = model.UnitsAvailable;
                product.CategoryId = model.CategoryId;
                product.TeamId = model.TeamId;

                if(model.Image != null)
                {
                    string imageUrl = model.Image.FileName;
                    string folderName = "products";
                    if (!await uploadService.UploadImage(model.Image, folderName))
                    {
                        imageUrl = "Default.png";
                    }
                    product.ImageURL = imageUrl;
                }
                await repository.SaveChangesAsync();
            }
        }




    }
}
