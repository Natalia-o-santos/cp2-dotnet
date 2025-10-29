namespace FleetRental.Domain.Entities;

public class Rental
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid RiderId { get; private set; }
    public Guid MotorcycleId { get; private set; }
    public DateTime StartDateUtc { get; private set; }
    public DateTime? EndDateUtc { get; private set; }
    public decimal DailyRate { get; private set; }

    public Rider Rider { get; private set; }
    public Motorcycle Motorcycle { get; private set; }

    public Rental(Guid riderId, Guid motorcycleId, DateTime startDateUtc, decimal dailyRate)
    {
        if (dailyRate <= 0) throw new ArgumentException("Diária deve ser positiva", nameof(dailyRate));
        if (startDateUtc.Kind != DateTimeKind.Utc) throw new ArgumentException("Use UTC", nameof(startDateUtc));

        RiderId = riderId;
        MotorcycleId = motorcycleId;
        StartDateUtc = startDateUtc;
        DailyRate = dailyRate;
    }

    public void Finish(DateTime endDateUtc)
    {
        if (endDateUtc.Kind != DateTimeKind.Utc) throw new ArgumentException("Use UTC", nameof(endDateUtc));
        if (endDateUtc <= StartDateUtc) throw new ArgumentException("Fim deve ser após o início", nameof(endDateUtc));
        EndDateUtc = endDateUtc;
    }
}
