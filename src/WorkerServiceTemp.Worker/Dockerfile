# Use the .NET runtime base image for the Worker service
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Use the .NET SDK base image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project files
COPY . .

# Restore dependencies and build the project
RUN dotnet restore src/WorkerServiceTemp.Worker/WorkerServiceTemp.Worker.csproj
RUN dotnet publish src/WorkerServiceTemp.Worker/WorkerServiceTemp.Worker.csproj -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WorkerServiceTemp.Worker.dll"]
