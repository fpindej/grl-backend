namespace GRL.Api.Dtos;

public record CreateDriverRequest(string FirstName, string LastName);

public record CreateDriverResponse(int Id, string FirstName, string LastName);

public record GetDriverResponse(int Id, string FirstName, string LastName);

public record UpdateDriverRequest(string FirstName, string LastName);

public record UpdateDriverResponse(int Id, string FirstName, string LastName);