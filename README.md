# WorkerServiceTemp

This is a .NET Worker Service application that connects to a SQL Server database using Dapper to retrieve and process data. The worker runs continuously and fetches data from a SQL Server database.

## Prerequisites

Before running the project, ensure you have the following:

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Docker (if running SQL Server in a container)
- SQL Server running (either locally or in a Docker container)

## Setup

### Step 1: Clone the Repository

Clone the repository to your local machine:

```bash
git clone https://github.com/yourusername/WorkerServiceTemp.git
cd WorkerServiceTemp
```

### Step 2: Set Up SQL Server

You can use a Docker container to run SQL Server if you don't have it set up locally. To run SQL Server in Docker, use the following command:

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server
```

### Step 3: Create the Database and Table

Connect to your SQL Server instance using sqlcmd or your preferred SQL client.

Run the following SQL commands to create the MyEntities table and insert sample data:

```bash
CREATE DATABASE WorkerServiceTempDB;

USE WorkerServiceTempDB;

CREATE TABLE MyEntities (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

INSERT INTO MyEntities (Name) VALUES
('Test Entity 1'),
('Test Entity 2'),
('Test Entity 3');
```

### Step 4: Configure the Connection String

In the appsettings.json file, update the connection string to point to your SQL Server instance (ensure the password matches what you set in the Docker container or local SQL Server setup):

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=WorkerServiceTempDB;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
  }
}
```


### Step 5: Build and Run the Project

```bash
dotnet build
dotnet run --project src/WorkerServiceTemp.Worker/WorkerServiceTemp.Worker.csproj
```

### Step 6: Test the Worker

Once the worker service is running, it will fetch the data from the MyEntities table every 5 seconds and print the results to the console.