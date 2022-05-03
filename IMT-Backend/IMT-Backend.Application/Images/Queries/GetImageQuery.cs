using FluentValidation;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using MediatR;

namespace IMT_Backend.Application.Images.Queries
{
    public class GetImageQuery : IRequest<AppImage>
    {
        public Guid ImageId { get; set; }
    }

    public class GetImageQueryHandler : IRequestHandler<GetImageQuery, AppImage>
    {
        private readonly IAppImageRepository _appImageRepository;
        public GetImageQueryHandler(IAppImageRepository appImageRepository)
        {
            _appImageRepository = appImageRepository;
        }

        public async Task<AppImage> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var image = await _appImageRepository.GetImage(request.ImageId);
            return image;
        }
    }
    public class GetImageQueryValidator : AbstractValidator<GetImageQuery>
    {
        public GetImageQueryValidator()
        {
            RuleFor(i => i.ImageId).NotNull();
        }
    }
}
