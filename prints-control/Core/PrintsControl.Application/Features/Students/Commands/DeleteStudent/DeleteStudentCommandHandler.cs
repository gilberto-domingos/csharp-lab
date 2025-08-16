using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Students.Commands.DeleteStudent;

public sealed class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand,DeleteStudentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public DeleteStudentCommandHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }


    public async Task<DeleteStudentResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (student is null) return default;

        await _studentRepository.DeleteAsync(student, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<DeleteStudentResponse>(student);

    }
}