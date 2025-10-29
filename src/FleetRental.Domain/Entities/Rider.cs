namespace FleetRental.Domain.Entities;

public class Rider
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FullName { get; private set; }
    public string DocumentNumber { get; private set; } // CPF
    public string Phone { get; private set; }
    public DateTime RegisteredAtUtc { get; private set; } = DateTime.UtcNow;

    public Rider(string fullName, string documentNumber, string phone)
    {
        Update(fullName, documentNumber, phone);
    }

    public void Update(string fullName, string documentNumber, string phone)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Nome é obrigatório", nameof(fullName));
        if (string.IsNullOrWhiteSpace(documentNumber))
            throw new ArgumentException("Documento é obrigatório", nameof(documentNumber));
        if (documentNumber.Length < 11)
            throw new ArgumentException("Documento inválido", nameof(documentNumber));
        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Telefone é obrigatório", nameof(phone));

        FullName = fullName.Trim();
        DocumentNumber = new string(documentNumber.Where(char.IsDigit).ToArray());
        Phone = phone.Trim();
    }
}
