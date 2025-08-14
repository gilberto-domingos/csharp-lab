using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Users;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Users.Commands.DeleteUser;

public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null) return default;

        await _userRepository.DeleteAsync(user,cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<DeleteUserResponse>(user);
    }
}