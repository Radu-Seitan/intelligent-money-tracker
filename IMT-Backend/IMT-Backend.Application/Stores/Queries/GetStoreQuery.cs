using AutoMapper;
using FluentValidation;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using MediatR;

namespace IMT_Backend.Application.Stores.Queries
{
    public class GetStoreQuery : IRequest<StoreDto>
    {
        public int StoreId { get; set; }
    }

    public class GetStoreQueryHandler : IRequestHandler<GetStoreQuery, StoreDto>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        public GetStoreQueryHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<StoreDto> Handle(GetStoreQuery request, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetStore(request.StoreId);

            return _mapper.Map<StoreDto>(store);
        }
    }
    public class GetStoreQueryValidator : AbstractValidator<GetStoreQuery>
    {
        public GetStoreQueryValidator()
        {
            RuleFor(s => s.StoreId).NotNull();
        }
    }
}
