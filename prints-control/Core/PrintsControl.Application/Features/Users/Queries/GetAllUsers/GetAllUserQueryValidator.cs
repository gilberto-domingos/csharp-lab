using FluentValidation;

namespace PrintsControl.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUserQueryValidator : AbstractValidator<GetAllUserQuery>
{
    public GetAllUserQueryValidator()
    {
        //sem validação
    }
}