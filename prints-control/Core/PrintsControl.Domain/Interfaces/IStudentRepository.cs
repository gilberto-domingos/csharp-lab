using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface IStudentRepository : IBaseRepository<Student>
{
    Task<Student> GetByNameAsync(string name, CancellationToken cancellationToken);
   
    Task<IEnumerable<Student>> GetAllWithHistoryAsync(CancellationToken cancellationToken);
}