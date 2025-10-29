using Microsoft.EntityFrameworkCore;
using FleetRental.Domain.Entities;
using FleetRental.Domain.Repositories;
using FleetRental.Infrastructure.Persistence;

namespace FleetRental.Infrastructure.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly AppDbContext _db;
    public RentalRepository(AppDbContext db) => _db = db;

    public async Task AddAsync(Rental rental, CancellationToken cancellationToken = default)
    {
        await _db.Rentals.AddAsync(rental, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public Task<Rental?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _db.Rentals
            .Include(x => x.Rider)
            .Include(x => x.Motorcycle)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Rental>> ListByRiderAsync(Guid riderId, CancellationToken cancellationToken = default)
    {
        return await _db.Rentals
            .Where(x => x.RiderId == riderId)
            .OrderByDescending(x => x.StartDateUtc)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Rental rental, CancellationToken cancellationToken = default)
    {
        _db.Rentals.Update(rental);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
