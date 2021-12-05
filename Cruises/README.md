# Cruises

Example of distributed caching web API.

I scaffolded the web application thanks to my cupcake mocaccino, a simple bash script available at the following link:

```text
https://github.com/paolomococci/mocaccino/blob/main/Cupcake/cupcake
```

```shell
./cupcake Cruises 2>error.log 1>out.log
```

## Database migration, with context /src/infrastructure/Cruises.Data/Contexts/ApplicationDbContext.cs

```shell
cd src/infrastructure/Cruises.Data
dotnet ef migrations add InitialCreate --context ApplicationDbContext  --startup-project ../../presentation/Cruises.WebApi/
dotnet ef database update --context ApplicationDbContext  --startup-project ../../presentation/Cruises.WebApi/
```
