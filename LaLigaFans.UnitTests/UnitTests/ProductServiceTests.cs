using LaLigaFans.Core.Contracts.CommentContracts;
using LaLigaFans.Core.Contracts.NewsContracts;
using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Contracts.ProductContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.News;
using LaLigaFans.Core.Services.CommentServices;
using LaLigaFans.Core.Services.NewsServices;
using LaLigaFans.Core.Services.OtherServices;
using LaLigaFans.Core.Services.ProductServices;
using LaLigaFans.Core.Services.TeamServices;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using LaLigaFans.Core.Models.Products;
using LaLigaFans.Infrastructure.Data.Models;

namespace LaLigaFans.UnitTests.UnitTests
{
    [TestFixture]
    public class ProductServiceTests : UnitTestsBase
    {
        private IProductService productService;

        private IUploadService uploadService;

        private ICommentService commentService;

        [OneTimeSetUp]
        public void SetUp()
        {
            uploadService = new UploadService();
            commentService = new CommentService(repository);
            productService = new ProductService(repository, uploadService, commentService);
        }

        [Test]
        public async Task AllAsync_ShouldReturnCorrectResult_WithValidUserId()
        {
            var products = await productService.AllAsync(string.Empty);

            var contextProducts = await context.Products.ToListAsync();

            Assert.That(products.TotalProductCount, Is.EqualTo(contextProducts.Count()));
        }

        [Test]
        public async Task AllCategoryNamesAsync_ShouldReturnCorrectData()
        {
            var categoriesNames = await productService.AllCategoriesNamesAsync();

            Assert.That(categoriesNames, Is.Not.Null);

            var categoriesCount = await context.Categories.CountAsync();

            Assert.That(categoriesNames.Count(), Is.EqualTo(categoriesCount));
        }

        [Test]
        public async Task ExistAsync_ShouldReturnTrue_WhitValidId()
        {
            var result = await productService.ExistAsync(Product1.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ProductDetailsByIdAsync_ShouldReturnCorrectData_WithValidId()
        {
            var product = await productService.ProductDetailsByIdAsync(Product1.Id);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.Name, Is.EqualTo(Product1.Name));
            Assert.That(product.Description, Is.EqualTo(Product1.Description));
            Assert.That(product.UnitsAvailable, Is.EqualTo(Product1.UnitsAvailable));
            Assert.That(product.Price, Is.EqualTo(Product1.Price));
        }

        [Test]
        public async Task CreateAsync_ShouldCreateProduct()
        {
            var productsCountBefore = context.Products.Count();

            //Create fake IFormFile for test upload service
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);


            var newProduct = new ProductAddFormModel()
            {
                Name = "ProductName",
                Description = "Original Barcelona scarf made of cotton and synthetic fabric.",
                CategoryId = Category1.Id,
                Image = file,
                TeamId = Team1.Id,
                Price = 15.99M,
                UnitsAvailable = 10
            };

            var newProductId = await productService.CreateAsync(newProduct);

            var productsCountAfter = context.Products.Count();

            Assert.That(productsCountAfter, Is.EqualTo(productsCountBefore + 1));

            var newProductInDb = context.Products
                .Where(p => p.Id == newProductId).FirstOrDefault();

            Assert.That(newProductInDb, Is.Not.Null);
            Assert.That(newProductInDb.Name, Is.EqualTo(newProduct.Name));
            Assert.That(newProductInDb.TeamId, Is.EqualTo(newProduct.TeamId));
            Assert.That(newProductInDb.Description, Is.EqualTo(newProduct.Description));
            Assert.That(newProductInDb.Price, Is.EqualTo(newProduct.Price));
            Assert.That(newProductInDb.CategoryId, Is.EqualTo(newProduct.CategoryId));
        }

        [Test]
        public async Task CategoryExistsAsync_ShouldReturnTrue_WhitValidId()
        {
            var result = await productService.CategoryExistsAsync(Category1.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DeleteAsync_ShouldChangeIsActivePropertyToFalse_WithValidId()
        {
            var product = new Product()
            {
                Name = "Barcelona Scarf",
                Description = "Original Barcelona scarf made of cotton and synthetic fabric.",
                ImageURL = "BarcaScarf.png",
                Price = 22.99M,
                UnitsAvailable = 10,
                CategoryId = Category2.Id,
                TeamId = Team1.Id,
                IsActive = true,
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            await productService.DeleteAsync(product.Id);

            Assert.That(product.IsActive, Is.EqualTo(false));
        }








    }
}
