using Microsoft.EntityFrameworkCore;
using FleetRental.Domain.Entities;
using FleetRental.Domain.Repositories;
using FleetRental.Infrastructure.Persistence;

namespace FleetRental.Infrastructure.Repositories;

public class MotorcycleRepository : IMotorcycleRepository
{
    private readonly AppDbContext _db;
    public MotorcycleRepository(AppDbContext db) => _db = db;

    public async Task AddAsync(Motorcycle motorcycle, CancellationToken cancellationToken = default)
    {
        await _db.Motorcycles.AddAsync(motorcycle, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Motorcycle motorcycle, CancellationToken cancellationToken = default)
    {
        _db.Motorcycles.Remove(motorcycle);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsByPlateAsync(string plate, CancellationToken cancellationToken = default)
    {
        var p = plate.Trim().ToUpperInvariant();
        return _db.Motorcycles.AnyAsync(x => x.Plate == p, cancellationToken);
    }

    public Task<Motorcycle?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _db.Motorcycles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Motorcycle>> ListAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _db.Motorcycles
            .OrderByDescending(x => x.RegisteredAtUtc)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Motorcycle motorcycle, CancellationToken cancellationToken = default)
    {
        _db.Motorcycles.Update(motorcycle);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
