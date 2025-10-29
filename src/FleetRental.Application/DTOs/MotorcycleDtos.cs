namespace FleetRental.Application.DTOs;

public record MotorcycleCreateRequest(string Plate, string Model, int Year);
public record MotorcycleUpdateRequest(string Plate, string Model, int Year);
public record MotorcycleResponse(Guid Id, string Plate, string Model, int Year, DateTime RegisteredAtUtc);
