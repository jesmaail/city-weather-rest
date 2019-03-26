# City Weather Rest

## Setup

### SQL

Local instance should work fine, but I used docker with the following:

`docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Letmein123!' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest`

You can then run CityWeather.DbUp to create the Database, table, and stored procedures (Will need the correct Connection string).

__Connection String__

This is stored inside:
- `appsettings.json` in CityWeather.API
- `Program.cs` in CityWeather.DbUp.

---

## Usage
There is a provided Postman Collection which has the endpoint queries for the Service.

---

## Nice-to-haves I've missed
- More in depth unit tests, particularly ensuring the Rest classes were called.
- Better Try Catch for exceptions.
- Seeding script for DbUp.
- Docker Compose.