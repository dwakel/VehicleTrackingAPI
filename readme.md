
# Development Environment

## Dependencies

- dotnet-core sdk:`>=2.2`


# Quickstart

- Run Migrations:
  PowerShell Command: `Update-Database`
or package manager console of visual studio

CLI Command:`dotnet ef database update`


## Configuration

You need to create a configuration file in each project called `appsettings.Development.json` with

```json
{
  "ConnectionStrings": {
    "GpsConnection": "Server=(localdb)\\mssqllocaldb;Database=Gps;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "AppSettings": {
    "Secret": "ThisIsaTemporalKey"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  }
}
```