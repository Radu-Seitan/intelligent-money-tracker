using FluentValidation;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using MediatR;

namespace IMT_Backend.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public double Sum { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.Id,
                Username = request.Username,
                Sum = request.Sum,
                Incomes = new List<Income>(),
                Expenses = new List<Expense>()
            };

            await _userRepository.CreateUser(user);
            return Unit.Value;
        }
    }
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Id)
                .NotNull();
            RuleFor(u => u.Username)
                .MaximumLength(40)
                .NotNull();
            RuleFor(u => u.Sum)
                .NotNull();
        }
    }
}
