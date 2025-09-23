using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.Students;

public class GetAllStudentHistoryQueryHandler:IRequestHandler<GetAllStudentHistoryQuery, StudentHistoryDto>
{
    private readonly IStudentRepository _repository;
    private readonly IMapper _mapper;

    public GetAllStudentHistoryQueryHandler(IStudentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<StudentHistoryDto> Handle(GetAllStudentHistoryQuery request, CancellationToken cancellationToken)
    {
        var historyStudent = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<StudentHistoryDto>(historyStudent);
    }
}