using GRL.Application.Services;
using GRL.Domain.Entities;
using GRL.Domain.Repositories;

namespace GRL.Infrastructure.Services;

public class DriverService : IDriverService
{
    private readonly IDriverRepository _driverRepository;

    public DriverService(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<List<Driver>> GetAllDriversAsync()
    {
        return (await _driverRepository.GetAllAsync()).ToList();
    }

    public async Task<Driver> GetDriverByIdAsync(int id)
    {
        return await _driverRepository.GetByIdAsync(id);
    }

    public async Task<Driver> AddDriverAsync(string firstName, string lastName)
    {
        var driver = new Driver(firstName, lastName);
        var createdDriver = await _driverRepository.AddAsync(driver);

        return createdDriver;
    }

    public async Task<Driver> UpdateDriverAsync(int id, string firstName, string lastName)
    {
        var driverToUpdate = new Driver(firstName, lastName)
        {
            Id = id
        };

        await _driverRepository.UpdateAsync(driverToUpdate);
        await _driverRepository.SaveChangesAsync();

        var updatedDriver = await _driverRepository.GetByIdAsync(id);
        if (updatedDriver is null)
            throw new KeyNotFoundException($"Driver with ID {id} not found after update.");

        return updatedDriver;
    }

    public async Task DeleteDriverAsync(int id)
    {
        await _driverRepository.DeleteAsync(id);
        await _driverRepository.SaveChangesAsync();
    }
}