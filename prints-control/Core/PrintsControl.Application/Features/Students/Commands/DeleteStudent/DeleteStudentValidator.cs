using FluentValidation;

namespace PrintsControl.Application.Features.Students.Commands.DeleteStudent;

public class DeleteStudentValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentValidator()
    {
        RuleFor(x => x.Id).NotEmpty();  
    }
}