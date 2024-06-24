
# Boilerplate API

1. Clone the project
3. Clone file ```appsettings.Development.json``` and rename it to ```appsettings.json```
4. Change environment variables
5. Raise the PostgreSQL database container

```
docker-compose up -d
```
6. Execute migrations:

```
dotnet ef migrations add InitDB
dotnet ef database update
```

7. Run the application: ```dotnet run```
 
 