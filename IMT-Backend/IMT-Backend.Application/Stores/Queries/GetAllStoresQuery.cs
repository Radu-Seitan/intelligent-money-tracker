using AutoMapper;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using MediatR;

namespace IMT_Backend.Application.Stores.Queries
{
    public class GetAllStoresQuery : IRequest<IEnumerable<StoreDto>>
    {
    }
    public class GetAllStoresQueryHandle : IRequestHandler<GetAllStoresQuery, IEnumerable<StoreDto>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        public GetAllStoresQueryHandle(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StoreDto>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetStores();
            return _mapper.Map<IEnumerable<StoreDto>>(stores);
        }
    }
}
