using FluentValidation;

namespace PrintsControl.Application.Features.Users.Queries;

public class GetAllUserValidator : AbstractValidator<GetAllUserQuery>
{
    public GetAllUserValidator()
    {
        //sem validação
    }
}