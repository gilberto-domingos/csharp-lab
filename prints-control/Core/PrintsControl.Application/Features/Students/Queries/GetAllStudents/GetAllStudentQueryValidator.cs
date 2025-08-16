using FluentValidation;

namespace PrintsControl.Application.Features.Students.Queries.GetAllStudents;

public class GetAllStudentQueryValidator : AbstractValidator<GetAllStudentsQuery>
{
    public GetAllStudentQueryValidator()
    {
        // sem validação
    }
}