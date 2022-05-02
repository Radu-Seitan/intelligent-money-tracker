using AutoMapper;
using FluentValidation;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using MediatR;

namespace IMT_Backend.Application.Users.Queries
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public string UserId { get; set; }
    }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.UserId);

            return _mapper.Map<UserDto>(user);
        }
    }

    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(u => u.UserId).NotNull();
        }
    }
}
