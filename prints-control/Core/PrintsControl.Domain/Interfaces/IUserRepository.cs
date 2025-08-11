using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);
}