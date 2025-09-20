using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public sealed class UnitOfWork : IUnitOfWork,  IDisposable
{
    private readonly AppDbContext _context;
    
    public IStudentRepository Students { get; }
    public IUserRepository Users { get; }

    public UnitOfWork(
        AppDbContext context,
        IStudentRepository studentRepository,
        IUserRepository userRepository)
    {
        _context = context;
        Students = studentRepository;
        Users = userRepository;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

}