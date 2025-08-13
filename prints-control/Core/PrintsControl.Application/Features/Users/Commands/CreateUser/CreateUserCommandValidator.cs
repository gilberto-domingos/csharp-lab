using FluentValidation;
namespace PrintsControl.Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}