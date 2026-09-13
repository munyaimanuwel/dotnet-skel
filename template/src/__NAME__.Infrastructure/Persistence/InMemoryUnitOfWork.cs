using __NAMESPACE__.Domain.Interfaces;

namespace __NAMESPACE__.Infrastructure.Persistence;

/// <summary>
/// Thin in-memory unit of work. Replace with EF / Postgres when ready.
/// </summary>
public sealed class InMemoryUnitOfWork : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(0);
}
