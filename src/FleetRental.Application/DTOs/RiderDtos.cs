namespace FleetRental.Application.DTOs;

public record RiderCreateRequest(string FullName, string DocumentNumber, string Phone);
public record RiderUpdateRequest(string FullName, string DocumentNumber, string Phone);
public record RiderResponse(Guid Id, string FullName, string DocumentNumber, string Phone, DateTime RegisteredAtUtc);

public record PagedResult<T>(IReadOnlyList<T> Items, int Page, int PageSize);
