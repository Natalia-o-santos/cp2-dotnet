using FleetRental.Application.DTOs;

namespace FleetRental.Application.Services;

public interface IRiderService
{
    Task<RiderResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PagedResult<RiderResponse>> ListAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<Guid> CreateAsync(RiderCreateRequest request, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Guid id, RiderUpdateRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
