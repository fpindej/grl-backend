using GRL.Domain.Entities;

namespace GRL.Application.Services;

public interface IDriverService
{
    Task<List<Driver>> GetAllDriversAsync();
    Task<Driver> GetDriverByIdAsync(int id);
    Task<Driver> AddDriverAsync(string firstName, string lastName);
    
    Task<Driver> UpdateDriverAsync(int id, string firstName, string lastName);
    Task DeleteDriverAsync(int id);
}