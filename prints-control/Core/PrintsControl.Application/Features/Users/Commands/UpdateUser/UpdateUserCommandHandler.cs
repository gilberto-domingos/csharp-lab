using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Users;
using PrintsControl.Application.Features.Users.Commands.CreateUser;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (user is null) return default;

        if (!string.IsNullOrWhiteSpace(command.Email))
            user.SetEmail(command.Email);
        
        if(!string.IsNullOrWhiteSpace(command.Password))
            user.SetPassword(command.Password);

        await _userRepository.UpdateAsync(user, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<UpdateUserResponse>(user);
    }
}