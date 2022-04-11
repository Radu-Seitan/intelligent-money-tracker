using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using IMT_Backend.Infrastructure.Persistence;

namespace IMT_Backend.Infrastructure.Repositories
{
    public class AppImageRepository : IAppImageRepository
    {
        private readonly AppDbContext _appDbContext;
        public AppImageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<AppImage> UploadImage(byte[] content, string type)
        {
            var appImage = new AppImage
            {
                Content = content,
                Type = type,
            };

            _appDbContext.Images.Add(appImage);
            await _appDbContext.SaveChangesAsync();
            return appImage;
        }

        public async Task DeleteImage(Guid imageId)
        {
            var image = await _appDbContext.Images.FindAsync(imageId);
            _appDbContext.Images.Remove(image);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<AppImage> GetImage(Guid imageId)
        {
            return await _appDbContext.Images.FindAsync(imageId);
        }
    }
}
