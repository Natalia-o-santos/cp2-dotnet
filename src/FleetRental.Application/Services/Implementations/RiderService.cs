using AutoMapper;
using FleetRental.Application.DTOs;
using FleetRental.Domain.Entities;
using FleetRental.Domain.Repositories;

namespace FleetRental.Application.Services.Implementations;

public class RiderService : IRiderService
{
    private readonly IRiderRepository _riderRepository;
    private readonly IMapper _mapper;

    public RiderService(IRiderRepository riderRepository, IMapper mapper)
    {
        _riderRepository = riderRepository;
        _mapper = mapper;
    }

    public async Task<RiderResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var rider = await _riderRepository.GetByIdAsync(id, cancellationToken);
        return rider is null ? null : _mapper.Map<RiderResponse>(rider);
    }

    public async Task<PagedResult<RiderResponse>> ListAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var items = await _riderRepository.ListAsync(page, pageSize, cancellationToken);
        var mapped = items.Select(_mapper.Map<RiderResponse>).ToList();
        return new PagedResult<RiderResponse>(mapped, page, pageSize);
    }

    public async Task<Guid> CreateAsync(RiderCreateRequest request, CancellationToken cancellationToken = default)
    {
        var exists = await _riderRepository.ExistsByDocumentAsync(request.DocumentNumber, cancellationToken);
        if (exists) throw new InvalidOperationException("Documento já cadastrado");

        var rider = new Rider(request.FullName, request.DocumentNumber, request.Phone);
        await _riderRepository.AddAsync(rider, cancellationToken);
        return rider.Id;
    }

    public async Task<bool> UpdateAsync(Guid id, RiderUpdateRequest request, CancellationToken cancellationToken = default)
    {
        var rider = await _riderRepository.GetByIdAsync(id, cancellationToken);
        if (rider is null) return false;

        rider.Update(request.FullName, request.DocumentNumber, request.Phone);
        await _riderRepository.UpdateAsync(rider, cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var rider = await _riderRepository.GetByIdAsync(id, cancellationToken);
        if (rider is null) return false;
        await _riderRepository.DeleteAsync(rider, cancellationToken);
        return true;
    }
}
