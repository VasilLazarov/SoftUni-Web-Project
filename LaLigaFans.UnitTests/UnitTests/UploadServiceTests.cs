using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Services.OtherServices;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;

namespace LaLigaFans.UnitTests.UnitTests
{
    [TestFixture]
    public class UploadServiceTests : UnitTestsBase
    {
        private IUploadService uploadService;

        [OneTimeSetUp]
        public void SetUp()
            => uploadService = new UploadService();

        [Test]
        public async Task UploadImage_ShouldReturnTrue_WhitValidId()
        {
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

            var folderName = "tests";

            var result = await uploadService.UploadImage(file, folderName);

            Assert.That(result, Is.True);
        }
    }
}
