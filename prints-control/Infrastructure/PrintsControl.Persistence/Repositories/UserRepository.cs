using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _context.Set<User>() 
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

        if (user == null)
            throw new ArgumentException("Usuário não encontrado.");

        return user;
    }
}