using FluentValidation;

namespace PrintsControl.Application.Features.Users.Queries.GetByIdUser;

public class GetByIdUserQueryValidator : AbstractValidator<GetByIdUserQuery>
{
    public GetByIdUserQueryValidator()
    {
        // sem validação
    }
}