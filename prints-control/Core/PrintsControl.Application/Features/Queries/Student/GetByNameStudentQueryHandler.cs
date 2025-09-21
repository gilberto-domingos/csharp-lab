using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.Student;

public class GetByNameStudentQueryHandler : IRequestHandler<GetByNameStudentQuery, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetByNameStudentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<StudentDto> Handle(GetByNameStudentQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByNameAsync(request.Name, cancellationToken);

        if (student is null)
            throw new KeyNotFoundException($"Estudante com nome '{request.Name}' não encontrado.");

        return _mapper.Map<StudentDto>(student);
    }
}