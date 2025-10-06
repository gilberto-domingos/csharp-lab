using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface IPurchaseRepository : IBaseRepository<Purchase>
{
    Task<Purchase?> GetByIdWidthStudent(Guid Id, CancellationToken cancellationToken);
    Task<List<Purchase>> GetPurchaseByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
}