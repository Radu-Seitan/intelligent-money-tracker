using AutoMapper;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using MediatR;

namespace IMT_Backend.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest <IEnumerable<UserDto>>
    {
    }
    public class GetAllUsersQueryHandle : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandle(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsers();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
