using FleetRental.Application.DTOs;

namespace FleetRental.Application.Services;

public interface IMotorcycleService
{
    Task<MotorcycleResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PagedResult<MotorcycleResponse>> ListAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<Guid> CreateAsync(MotorcycleCreateRequest request, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Guid id, MotorcycleUpdateRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
