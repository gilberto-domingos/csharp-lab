using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Commands.Students;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentDto>
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
    
    public async Task<StudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (student is null)
            throw new ArgumentException("Estudante não encontrado");

        await _studentRepository.UpdateAsync(student, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<StudentDto>(student);
    }
}