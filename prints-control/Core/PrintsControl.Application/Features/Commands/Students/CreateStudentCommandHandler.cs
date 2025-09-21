using AutoMapper;
using MediatR;
using PrintsControl.Domain.Entities;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Commands.Students;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    
    public CreateStudentCommandHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    
    public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Student>(request); 
        
        await _studentRepository.CreateAsync(student, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<StudentDto>(student);
    }
}