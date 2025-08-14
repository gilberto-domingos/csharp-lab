using FluentValidation;

namespace PrintsControl.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}