using FleetRental.Domain.Entities;

namespace FleetRental.Domain.Repositories;

public interface IRentalRepository
{
    Task<Rental?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Rental rental, CancellationToken cancellationToken = default);
    Task UpdateAsync(Rental rental, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Rental>> ListByRiderAsync(Guid riderId, CancellationToken cancellationToken = default);
}
