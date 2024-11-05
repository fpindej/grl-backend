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

    public async Task AddAsync(Driver driver)
    {
        var driverEntity = driver.ToModel();
        await _context.Drivers.AddAsync(driverEntity);
    }

    public void Delete(Driver driver)
    {
        var driverEntity = driver.ToModel();
        _context.Drivers.Remove(driverEntity);
    }

    public async Task<IEnumerable<Driver>> GetAllAsync()
    {
        var driverEntities = await _context.Drivers
            .ToListAsync();

        return driverEntities.Select(e => e.ToDomain());
    }

    public async Task<Driver?> GetByIdAsync(int id)
    {
        var driverEntity = await _context.Drivers
            .FirstOrDefaultAsync(d => d.Id == id);

        return driverEntity?.ToDomain();
    }

    public void Update(Driver driver)
    {
        var existingDriver = _context.Drivers.Find(driver.Id);

        if (existingDriver is null)
            throw new Exception("Driver not found.");

        existingDriver.FirstName = driver.FirstName;
        existingDriver.LastName = driver.LastName;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}