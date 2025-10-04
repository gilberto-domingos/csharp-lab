using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.Students;

public class GetAllStudentHistoryQueryHandler:IRequestHandler<GetAllStudentHistoryQuery, List<StudentHistoryDto>>
{
    private readonly IStudentRepository _repository;
    private readonly IMapper _mapper;

    public GetAllStudentHistoryQueryHandler(IStudentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<List<StudentHistoryDto>> Handle(GetAllStudentHistoryQuery request, CancellationToken cancellationToken)
    {
        var students = await _repository.GetAllAsync(cancellationToken);

        var historyList = students.Select(student => new StudentHistoryDto(
            student.Id,
            student.Name,
            student.Balance,
            student.Purchases.Sum(p => p.Quantity),              
            student.PrintJobs.Sum(p => p.Quantity),              
            student.Purchases.Select(p => p.PurchaseDate).ToList(), 
            student.PrintJobs.Select(p => p.PrintDate).ToList()     
        )).ToList();


        return historyList;

    }
}