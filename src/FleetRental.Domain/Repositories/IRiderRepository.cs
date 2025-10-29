using FleetRental.Domain.Entities;

namespace FleetRental.Domain.Repositories;

public interface IRiderRepository
{
    Task<Rider?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsByDocumentAsync(string documentNumber, CancellationToken cancellationToken = default);
    Task AddAsync(Rider rider, CancellationToken cancellationToken = default);
    Task UpdateAsync(Rider rider, CancellationToken cancellationToken = default);
    Task DeleteAsync(Rider rider, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Rider>> ListAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}
