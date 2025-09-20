namespace PrintsControl.Domain.Interfaces;

public interface IUnitOfWork
{
    IStudentRepository Students { get; }
    IUserRepository Users { get; }
    Task CommitAsync(CancellationToken cancellationToken);
}