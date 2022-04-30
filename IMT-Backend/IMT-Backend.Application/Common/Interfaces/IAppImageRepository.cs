using IMT_Backend.Domain.Entities;

namespace IMT_Backend.Application.Common.Interfaces
{
    public interface IAppImageRepository
    {
        Task<AppImage> UploadImage(byte[] content, string type, int storeId);
        Task DeleteImage(Guid imageId);
        Task<AppImage> GetImage(Guid imageId);
    }
}
