This is an API used to manage a car security System. This together https://github.com/dwakel/VehicleTrackingWebClient are used to monitor a vehicles location on a map. A default radius is set around a home location that a car owner chooses. Any voilation that is travelling outside the borders set by the vehicle owner will trigger an email alert to the owner of the vehicle.
This API provides realtime feedback sent from the vehicle or any device that is able to hit the API endpoint. It sintantly sends the location to the Web Application for the user to view his vehicle on the map

get Web App: https://github.com/dwakel/VehicleTrackingWebClient

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
