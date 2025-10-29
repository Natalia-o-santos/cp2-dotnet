using AutoMapper;
using FleetRental.Application.DTOs;
using FleetRental.Domain.Entities;
using FleetRental.Domain.Repositories;

namespace FleetRental.Application.Services.Implementations;

public class MotorcycleService : IMotorcycleService
{
    private readonly IMotorcycleRepository _motorcycleRepository;
    private readonly IMapper _mapper;

    public MotorcycleService(IMotorcycleRepository motorcycleRepository, IMapper mapper)
    {
        _motorcycleRepository = motorcycleRepository;
        _mapper = mapper;
    }

    public async Task<MotorcycleResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var moto = await _motorcycleRepository.GetByIdAsync(id, cancellationToken);
        return moto is null ? null : _mapper.Map<MotorcycleResponse>(moto);
    }

    public async Task<PagedResult<MotorcycleResponse>> ListAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var items = await _motorcycleRepository.ListAsync(page, pageSize, cancellationToken);
        var mapped = items.Select(_mapper.Map<MotorcycleResponse>).ToList();
        return new PagedResult<MotorcycleResponse>(mapped, page, pageSize);
    }

    public async Task<Guid> CreateAsync(MotorcycleCreateRequest request, CancellationToken cancellationToken = default)
    {
        var exists = await _motorcycleRepository.ExistsByPlateAsync(request.Plate, cancellationToken);
        if (exists) throw new InvalidOperationException("Placa já cadastrada");

        var moto = new Motorcycle(request.Plate, request.Model, request.Year);
        await _motorcycleRepository.AddAsync(moto, cancellationToken);
        return moto.Id;
    }

    public async Task<bool> UpdateAsync(Guid id, MotorcycleUpdateRequest request, CancellationToken cancellationToken = default)
    {
        var moto = await _motorcycleRepository.GetByIdAsync(id, cancellationToken);
        if (moto is null) return false;

        moto.Update(request.Plate, request.Model, request.Year);
        await _motorcycleRepository.UpdateAsync(moto, cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var moto = await _motorcycleRepository.GetByIdAsync(id, cancellationToken);
        if (moto is null) return false;
        await _motorcycleRepository.DeleteAsync(moto, cancellationToken);
        return true;
    }
}
