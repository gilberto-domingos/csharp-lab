using PrintsControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class StudentRepository : IBaseRepository<Student>, IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(Student entity, CancellationToken cancellationToken)
    {
        await _context.Students.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Students
            .AsNoTracking()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<List<Student>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Students
            .AsNoTracking()
            .IgnoreQueryFilters()   
            .OrderBy(s => s.Name)
            .ToListAsync(cancellationToken);
    }


    public async Task UpdateAsync(Student entity, CancellationToken cancellationToken)
    {
        entity.MarkAsUpdated();
        _context.Students.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Student entity, CancellationToken cancellationToken)
    {
         entity.MarkAsDeleted();
         _context.Students.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Student?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Name == name, cancellationToken);
    }

    public async Task<List<Student>> GetActiveStudentAsync(CancellationToken cancellationToken)
    {
        return await _context.Students
            .AsNoTracking()
            .OrderBy(s => s.Name)
            .ToListAsync(cancellationToken);
    }
}