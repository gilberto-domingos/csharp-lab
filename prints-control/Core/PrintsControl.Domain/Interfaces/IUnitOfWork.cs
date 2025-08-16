namespace PrintsControl.Domain.Interfaces;

public interface IUnitOfWork
{
    IStudentRepository Students { get; }
    IUserRepository Users { get; }
    ITransactionRepository Transactions { get; }
    Task CommitAsync(CancellationToken cancellationToken);
}