using GRL.Domain.Entities;
using GRL.Domain.Repositories;
using GRL.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GRL.Persistence.Repositories;

internal class DriverRepository : IDriverRepository
{
    private readonly GrlDbContext _context;

    public DriverRepository(GrlDbContext context)
    {
        _context = context;
    }

    public async Task<Driver> AddAsync(Driver driver)
    {
        var driverEntity = driver.ToModel();
        _ = await _context.Drivers.AddAsync(driverEntity);
        // Not ideal, consider creating a transaction layer in the future.
        await SaveChangesAsync();

        return driverEntity.ToDomain();
    }

    public async Task DeleteAsync(int id)
    {
        var existingDriver = await _context.Drivers.FindAsync(id);

        if (existingDriver is null)
            throw new KeyNotFoundException($"Driver with ID {id} not found.");
        
        _context.Drivers.Remove(existingDriver);
    }

    public async Task<IEnumerable<Driver>> GetAllAsync()
    {
        var driverEntities = await _context.Drivers
            .ToListAsync();

        return driverEntities.Select(e => e.ToDomain());
    }

    public async Task<Driver> GetByIdAsync(int id)
    {
        var existingDriver = await _context.Drivers
            .FirstOrDefaultAsync(d => d.Id == id);

        if (existingDriver is null)
        {
            throw new KeyNotFoundException($"Driver with ID {id} not found.");
        }

        return existingDriver.ToDomain();
    }

    public async Task<Driver> UpdateAsync(Driver driver)
    {
        var existingDriver = await _context.Drivers.FindAsync(driver.Id);

        if (existingDriver is null)
            throw new KeyNotFoundException($"Driver with ID {driver.Id} not found.");

        existingDriver.FirstName = driver.FirstName;
        existingDriver.LastName = driver.LastName;

        return existingDriver.ToDomain();
    }


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}