using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Commands.Students;

public sealed class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand,StudentDto>
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


    public async Task<StudentDto> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (student is null)
            throw new ArgumentException("Estudando não encontrado");
        
        var studentDto = _mapper.Map<StudentDto>(student);

        await _studentRepository.DeleteAsync(student, cancellationToken);
            
        await _unitOfWork.CommitAsync(cancellationToken);

        return studentDto;
    }
}