using Microsoft.EntityFrameworkCore;
using Study.Domain.Entities;

namespace Study.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<TodoItem> TodoItems { get; }
    DbSet<Tag> Tags { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
