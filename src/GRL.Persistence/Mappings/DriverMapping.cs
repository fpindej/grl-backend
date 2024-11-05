using GRL.Domain.Entities;

namespace GRL.Persistence.Mappings;

internal static class DriverMapping
{
    public static Models.Driver ToModel(this Driver driver)
    {
        return new Models.Driver
        {
            Id = driver.Id,
            FirstName = driver.FirstName,
            LastName = driver.LastName
        };
    }

    public static Driver ToDomain(this Models.Driver driverModel)
    {
        return new Driver(driverModel.FirstName, driverModel.LastName)
        {
            Id = driverModel.Id
        };
    }
}