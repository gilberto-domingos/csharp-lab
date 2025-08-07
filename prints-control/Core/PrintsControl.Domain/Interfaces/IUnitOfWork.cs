namespace PrintsControl.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken);
    void Rollback(); 
}