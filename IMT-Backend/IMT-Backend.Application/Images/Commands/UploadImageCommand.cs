using IMT_Backend.Application.Common.Interfaces;
using MediatR;

namespace IMT_Backend.Application.Images.Commands
{
    public class UploadImageCommand : IRequest<Guid>
    {
        public byte[] Content { get; set; }
        public string Type { get; set; }
        public int StoreId { get; set; }
    }

    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Guid>
    {
        private readonly IAppImageRepository _appImageRepository;
        private readonly IStoreRepository _storeRepository;
        public UploadImageCommandHandler(IAppImageRepository appImageRepository, IStoreRepository storeRepository)
        {
            _appImageRepository = appImageRepository;
            _storeRepository = storeRepository;
        }
        public async Task<Guid> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _appImageRepository.UploadImage(request.Content, request.Type, request.StoreId);
            var store = await _storeRepository.GetStore(request.StoreId);

            store.ImageId = image.Id;

            return image.Id;
        }
    }
}
