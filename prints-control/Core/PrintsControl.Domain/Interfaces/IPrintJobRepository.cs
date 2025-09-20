using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface IPrintJobRepository : IBaseRepository<PrintJob>
{
    Task<List<PrintJob>> GetPrintJobStudentIdAsync(Guid studentId, CancellationToken cancellationToken);

    Task<PrintJob?> GetLastPrintJobStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
}