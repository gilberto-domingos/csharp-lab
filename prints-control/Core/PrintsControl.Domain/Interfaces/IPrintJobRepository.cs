using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface IPrintJobRepository : IBaseRepository<PrintJob>
{
    Task<PrintJob> GetByIdWidthStudent(Guid id, CancellationToken cancellationToken);
    Task<List<PrintJob>> GetPrintJobStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
}