# Biking

Securing the application thanks to JWT.

Scaffolding performed using my bash cupcake script available at my repository named mocaccino.
This script is available at the following link:

```text
https://github.com/paolomococci/mocaccino/blob/main/Cupcake/cupcake
```

## Database migration, with context /src/infrastructure/Biking.Data/Contexts/ApplicationDbContext.cs

```shell
cd src/infrastructure/Biking.Data
dotnet ef migrations add InitialCreate --context ApplicationDbContext  --startup-project ../../presentation/Biking.WebApi/
dotnet ef database update --context ApplicationDbContext  --startup-project ../../presentation/Biking.WebApi/
```
