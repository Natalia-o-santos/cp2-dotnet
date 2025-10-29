using FleetRental.Domain.Entities;

namespace FleetRental.Domain.Repositories;

public interface IMotorcycleRepository
{
    Task<Motorcycle?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsByPlateAsync(string plate, CancellationToken cancellationToken = default);
    Task AddAsync(Motorcycle motorcycle, CancellationToken cancellationToken = default);
    Task UpdateAsync(Motorcycle motorcycle, CancellationToken cancellationToken = default);
    Task DeleteAsync(Motorcycle motorcycle, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Motorcycle>> ListAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}
