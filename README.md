# solita-vaccine-2021-blazor

## Built With

- [Blazor WASM](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-5.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

## Setup

### Requirements

- [.NET 5](https://dotnet.microsoft.com/download/dotnet)
- [dotnet CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/)
- [EF Core tools CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Recommended: [Docker](https://www.docker.com/)

### Running SQL Server on Docker

I would recommend to use Docker and run SQL Server image for fast and easy database setup.

Oneliner to run SQL Server on Windows and Apple Intel with docker:

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=VeryStrongPass123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

Oneliner to run SQL Server on Apple M1 with docker:

```sh
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=VeryStrongPass123" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
```

### Installation

1. Clone this repository:

```
git clone https://github.com/Muugmaster/solita-vaccine-2021-blazor.git
```

2. Go to project root where you find `VaccineApp.sln` and run `dotnet build`

3. Let's setup SQL Server connection. Move to `VaccineApp/Server` and create `appsettings.Development.json` and add this and change your connection string:

```json
{
  "ConnectionStrings": {
    "SQLServer": "YOUR CONNECTION STRING HERE"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

If you used docker setup you can add this connection string: `"Data Source=localhost;Initial Catalog=SolitaTest;Integrated Security=False;User Id=sa;Password=VeryStrongPass123;MultipleActiveResultSets=True"`

4. Go to `VaccineApp/Server` and run `dotnet ef database update` to update your database from migrations. You can check from `Migrations` folder what is created in database. Basically it created database, tables and seeds some inital data.

5. Start development server: `dotnet run` or start it in watch mode: `dotnet watch run`.
6. Open your browser and go to: `https://localhost:5001/`.
