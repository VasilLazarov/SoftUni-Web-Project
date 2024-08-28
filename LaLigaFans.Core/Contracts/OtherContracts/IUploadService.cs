using Microsoft.AspNetCore.Http;

namespace LaLigaFans.Core.Contracts.OtherContracts
{
    public interface IUploadService
    {
        Task<bool> UploadImage(IFormFile image, string folderName);
    }
}
