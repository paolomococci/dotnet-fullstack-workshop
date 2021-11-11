# Voyage

I scaffolded the web application thanks to my cupcake mocha, a simple bash script available at the following link:

```text
https://github.com/paolomococci/mocaccino/blob/main/Cupcake/cupcake
```

```shell
./cupcake Voyage
```

## I had to add some specific packages due to some incompatibilities

### into the Voyage.WebApi project

```shell
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.12
```

### into the Voyage.Data project

```shell
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 5.0.12
```

### into the Voyage.Application

```shell
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.12
```

## now, the list of packages in each project

```text

Project 'Voyage.Domain' has the following package references
   [netstandard2.1]: No packages were found for this framework.

Project 'Voyage.Application' has the following package references
   [netstandard2.1]:
   Top-level Package                                          Requested   Resolved
   > AutoMapper                                               10.1.1      10.1.1
   > AutoMapper.Extensions.Microsoft.DependencyInjection      8.1.1       8.1.1
   > FluentValidation                                         10.3.4      10.3.4
   > FluentValidation.DependencyInjectionExtensions           10.3.4      10.3.4
   > MediatR                                                  9.0.0       9.0.0
   > MediatR.Extensions.Microsoft.DependencyInjection         9.0.0       9.0.0
   > Microsoft.EntityFrameworkCore                            5.0.12      5.0.12
   > Microsoft.Extensions.Logging.Abstractions                6.0.0       6.0.0

Project 'Voyage.Data' has the following package references
   [net5.0]:
   Top-level Package                           Requested   Resolved
   > Microsoft.EntityFrameworkCore.Sqlite      5.0.12      5.0.12

Project 'Voyage.Shared' has the following package references
   [net5.0]:
   Top-level Package                                           Requested   Resolved
   > CsvHelper                                                 27.1.1      27.1.1
   > MailKit                                                   2.15.0      2.15.0
   > Microsoft.Extensions.Options.ConfigurationExtensions      6.0.0       6.0.0
   > MimeKit                                                   2.15.1      2.15.1

Project 'Voyage.WebApi' has the following package references
   [net5.0]:
   Top-level Package                           Requested   Resolved
   > Microsoft.EntityFrameworkCore.Design      5.0.12      5.0.12
   > Swashbuckle.AspNetCore                    5.6.3       5.6.3

```
