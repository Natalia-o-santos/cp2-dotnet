namespace FleetRental.Domain.Entities;

public class Motorcycle
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Plate { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public DateTime RegisteredAtUtc { get; private set; } = DateTime.UtcNow;

    public Motorcycle(string plate, string model, int year)
    {
        Update(plate, model, year);
    }

    public void Update(string plate, string model, int year)
    {
        if (string.IsNullOrWhiteSpace(plate))
            throw new ArgumentException("Placa é obrigatória", nameof(plate));
        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Modelo é obrigatório", nameof(model));
        if (year < 2000 || year > DateTime.UtcNow.Year + 1)
            throw new ArgumentException("Ano inválido", nameof(year));

        Plate = plate.Trim().ToUpperInvariant();
        Model = model.Trim();
        Year = year;
    }
}
