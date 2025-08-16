using FluentValidation;

namespace PrintsControl.Application.Features.Students.Commands.CreateStudent;

public sealed class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome do estudante é obrigatório.")
            .MaximumLength(50).WithMessage("O nome do estudante deve ter no máximo 150 caracteres.");
        
        RuleFor(x => x.PrintBalance)
            .GreaterThanOrEqualTo(0).WithMessage("O saldo inicial de impressões não pode ser negativo.");
    }
}