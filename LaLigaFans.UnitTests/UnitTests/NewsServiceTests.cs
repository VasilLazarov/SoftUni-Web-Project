using LaLigaFans.Core.Contracts.CommentContracts;
using LaLigaFans.Core.Contracts.NewsContracts;
using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Models.News;
using LaLigaFans.Core.Services.CommentServices;
using LaLigaFans.Core.Services.NewsServices;
using LaLigaFans.Core.Services.OtherServices;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.UnitTests.UnitTests
{
    [TestFixture]
    public class NewsServiceTests : UnitTestsBase
    {
        private INewsService newsService;

        private IUploadService uploadService;

        private ICommentService commentService;

        [OneTimeSetUp]
        public void SetUp()
        {
            uploadService = new UploadService();
            commentService = new CommentService(repository);
            newsService = new NewsService(repository, uploadService, commentService);
        }

        [Test]
        public async Task AllAsync_ShouldReturnCorrectResult_WithValidUserId()
        {
            var news = await newsService.AllAsync(string.Empty);

            var contextNews = await context.News.ToListAsync();

            Assert.That(news.TotalNewsCount, Is.EqualTo(contextNews.Count()));
        }

        [Test]
        public async Task HasPublisherWithIdAsync_ShouldReturnTrue_WithValidIds()
        {
            bool result = await newsService.HasPublisherWithIdAsync(News1.Id, Publisher1.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue_WhitValidId()
        {
            var result = await newsService.ExistsAsync(News1.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task NewsDetailsByIdAsync_ShouldReturnCorrectData_WithValidId()
        {
            var news = await newsService.NewsDetailsByIdAsync(News1.Id);

            Assert.That(news, Is.Not.Null);
            Assert.That(news.Title, Is.EqualTo(News1.Title));
            Assert.That(news.ImageUrl, Is.EqualTo(News1.ImageURL));
            Assert.That(news.Content, Is.EqualTo(News1.Content));
        }

        [Test]
        public async Task CreateAsync_ShouldCreateNews()
        {
            var newsCountBefore = context.News.Count();

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


            var newNews = new NewsAddFormModel()
            {
                Title = "NewsAddedTitle",
                Image = file,
                TeamId = Team1.Id,
                Content = "The Barcelona team won 3:2 away from Paris Saint-Germain in the first 1/4-final match of the Champions League.\r\nRafinha gave the Catalans the lead in the 37th minute, but early in the second half PSG made a quick turnaround through Ousmane Dembele in the 48th minute and Vitinha in the 51st minute. After that, however, the Catalans took the initiative again and in the 62nd minute the tie was restored with Rafinha's second goal. In the end, the final result was shaped by Andreas Christensen's goal in the 77th minute, which brought victory to Barca.\r\nThe second match between the two teams will be on April 16th in Spain, where we can expect another very interesting match."            
            };

            var newNewsId = await newsService.CreateAsync(newNews, Publisher2.Id);

            var newsCountAfter = context.News.Count();

            Assert.That(newsCountAfter, Is.EqualTo(newsCountBefore + 1));

            var newNewsInDb = context.News
                .Where(t => t.Id == newNewsId).FirstOrDefault();

            Assert.That(newNewsInDb, Is.Not.Null);
            Assert.That(newNewsInDb.Title, Is.EqualTo(newNews.Title));
            Assert.That(newNewsInDb.TeamId, Is.EqualTo(newNews.TeamId));
            Assert.That(newNewsInDb.Content, Is.EqualTo(newNews.Content));
        }

        [Test]
        public async Task GetNewsEditFormModelByIdAsync_ShouldReturnCorrectData_WithValidId()
        {
            var newsForEdit = await newsService.GetNewsEditFormModelByIdAsync(News1.Id);

            Assert.That(newsForEdit, Is.Not.Null);
            Assert.That(newsForEdit.Title, Is.EqualTo(News1.Title));
            Assert.That(newsForEdit.TeamId, Is.EqualTo(News1.TeamId));
            Assert.That(newsForEdit.Content, Is.EqualTo(News1.Content));
        }

        [Test]
        public async Task EditAsync_ShouldEditTeamCorrectly()
        {
            var news = new News()
            {
                Title = "NewsAddedTitle",
                ImageURL = "NewsUrlImage.png",
                TeamId = Team1.Id,
                Content = "The Barcelona team won 3:2 away from Paris Saint-Germain in the first 1/4-final match of the Champions League.\r\nRafinha gave the Catalans the lead in the 37th minute, but early in the second half PSG made a quick turnaround through Ousmane Dembele in the 48th minute and Vitinha in the 51st minute. After that, however, the Catalans took the initiative again and in the 62nd minute the tie was restored with Rafinha's second goal. In the end, the final result was shaped by Andreas Christensen's goal in the 77th minute, which brought victory to Barca.\r\nThe second match between the two teams will be on April 16th in Spain, where we can expect another very interesting match.",
                IsActive = true,
                PublishedOn = DateTime.Now,
                OwnerId = Publisher1.Id
            };

            await context.News.AddAsync(news);
            await context.SaveChangesAsync();

            var changedTitle = "EditedNewsTitle";

            var newsEditFormModel = new NewsEditFormModel()
            {
                Title = changedTitle,
                Image = null,
                TeamId = news.TeamId,
                Content = news.Content
            };

            await newsService.EditAsync(news.Id, newsEditFormModel);

            var newNewsInDb = await context.News
                .FindAsync(news.Id);

            Assert.That(newNewsInDb, Is.Not.Null);
            Assert.That(newNewsInDb.Title, Is.EqualTo(changedTitle));
            Assert.That(newNewsInDb.TeamId, Is.EqualTo(news.TeamId));
            Assert.That(newNewsInDb.Content, Is.EqualTo(news.Content));
        }

        [Test]
        public async Task DeleteAsync_ShouldChangeIsActivePropertyToFalse_WithValidId()
        {
            var news = new News()
            {
                Title = "NewsAddedTitle",
                ImageURL = "NewsUrlImage.png",
                TeamId = Team1.Id,
                Content = "The Barcelona team won 3:2 away from Paris Saint-Germain in the first 1/4-final match of the Champions League.\r\nRafinha gave the Catalans the lead in the 37th minute, but early in the second half PSG made a quick turnaround through Ousmane Dembele in the 48th minute and Vitinha in the 51st minute. After that, however, the Catalans took the initiative again and in the 62nd minute the tie was restored with Rafinha's second goal. In the end, the final result was shaped by Andreas Christensen's goal in the 77th minute, which brought victory to Barca.\r\nThe second match between the two teams will be on April 16th in Spain, where we can expect another very interesting match.",
                IsActive = true,
                PublishedOn = DateTime.Now,
                OwnerId = Publisher1.Id
            };

            await context.News.AddAsync(news);
            await context.SaveChangesAsync();

            await newsService.DeleteAsync(news.Id);

            Assert.That(news.IsActive, Is.EqualTo(false));
        }

        [Test]
        public async Task GetNewsDeleteServiceModelByIdAsync_ShouldReturnCorrectData_WithValidId()
        {
            var newsForDelete = await newsService.GetNewsDeleteServiceModelByIdAsync(News1.Id);

            Assert.That(newsForDelete, Is.Not.Null);
            Assert.That(newsForDelete.Title, Is.EqualTo(News1.Title));
            Assert.That(newsForDelete.ImageUrl, Is.EqualTo(News1.ImageURL));
            Assert.That(newsForDelete.Content, Is.EqualTo(News1.Content));
            Assert.That(newsForDelete.TeamName, Is.EqualTo(News1.Team.Name));
        }


    }
}
