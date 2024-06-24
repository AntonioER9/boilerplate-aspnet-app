
# Boilerplate API

1. Clone the project
3. Clone file ```.env.template``` and rename it to ```.env```
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
 
 