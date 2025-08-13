using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Users;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        await _userRepository.CreateAsync(user, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<CreateUserResponse>(user);
    }
}