using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<Student> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);
}