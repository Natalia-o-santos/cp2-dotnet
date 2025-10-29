using Microsoft.EntityFrameworkCore;
using FleetRental.Domain.Entities;
using FleetRental.Domain.Repositories;
using FleetRental.Infrastructure.Persistence;

namespace FleetRental.Infrastructure.Repositories;

public class RiderRepository : IRiderRepository
{
    private readonly AppDbContext _db;
    public RiderRepository(AppDbContext db) => _db = db;

    public async Task AddAsync(Rider rider, CancellationToken cancellationToken = default)
    {
        await _db.Riders.AddAsync(rider, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Rider rider, CancellationToken cancellationToken = default)
    {
        _db.Riders.Remove(rider);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsByDocumentAsync(string documentNumber, CancellationToken cancellationToken = default)
    {
        var doc = new string(documentNumber.Where(char.IsDigit).ToArray());
        return _db.Riders.AnyAsync(x => x.DocumentNumber == doc, cancellationToken);
    }

    public Task<Rider?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _db.Riders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Rider>> ListAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _db.Riders
            .OrderByDescending(x => x.RegisteredAtUtc)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Rider rider, CancellationToken cancellationToken = default)
    {
        _db.Riders.Update(rider);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
