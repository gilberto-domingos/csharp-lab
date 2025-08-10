using FluentValidation;

namespace PrintsControl.Application.UseCases.CreateUser.Commands;

public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
    
}