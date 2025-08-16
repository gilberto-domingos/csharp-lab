using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Application.Features.Users.Commands.UpdateUser;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Students.Commands.UpdateStudent;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentResponse>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public UpdateStudentCommandHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    
    public async Task<UpdateStudentResponse> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(command.Id, cancellationToken);

        if (student is null) return default;
        
        if (!string.IsNullOrWhiteSpace(command.Name))
            student.SetName(command.Name);

        await _studentRepository.UpdateAsync(student, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<UpdateStudentResponse>(student);
    }
}