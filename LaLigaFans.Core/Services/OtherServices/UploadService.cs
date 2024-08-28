using LaLigaFans.Core.Contracts.OtherContracts;
using Microsoft.AspNetCore.Http;

namespace LaLigaFans.Core.Services.OtherServices
{
    public class UploadService : IUploadService
    {
        public async Task<bool> UploadImage(IFormFile image, string folderName)
        {
            bool result = false;

            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot", "img", folderName);

            string fileName = Path.Combine(path, image.FileName);

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
                result = true;
            }

            return result;
        }
    }
}
