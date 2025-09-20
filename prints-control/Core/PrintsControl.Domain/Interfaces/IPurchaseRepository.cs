using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface IPurchaseRepository : IBaseRepository<Purchase>
{
    Task<List<Purchase>> GetPurchaseByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);

    Task<Purchase?> GelLastPurchaseByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
}