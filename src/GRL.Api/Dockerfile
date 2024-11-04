# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["GRL.Api/GRL.Api.csproj", "GRL.Api/"]
RUN dotnet restore "GRL.Api/GRL.Api.csproj"

# Copy the entire source code
COPY . .

# Build the application
WORKDIR "/src/GRL.Api"
RUN dotnet build "GRL.Api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "GRL.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false /p:DebugType=None /p:DebugSymbols=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port 5001
EXPOSE 5001

ENTRYPOINT ["dotnet", "GRL.Api.dll", "--urls", "http://0.0.0.0:5001"]
