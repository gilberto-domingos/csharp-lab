using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.Students;

public class GetAllStudentHistoryQueryHandler:IRequestHandler<GetAllStudentHistoryQuery, List<StudentHistoryDto>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetAllStudentHistoryQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    
    public async Task<List<StudentHistoryDto>> Handle(GetAllStudentHistoryQuery request, CancellationToken cancellationToken)
    {
        var studentsHistory = await _studentRepository.GetAllWithHistoryAsync(cancellationToken);

        return _mapper.Map<List<StudentHistoryDto>>(studentsHistory);

    }
}