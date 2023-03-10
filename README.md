[![.NET](https://github.com/brhvucn/Boilerplate_ASPNETMVC/actions/workflows/dotnet.yml/badge.svg)](https://github.com/brhvucn/Boilerplate_ASPNETMVC/actions/workflows/dotnet.yml)

# Boilerplate ASP.NET MVC
This is a sample implementation of a simple ASP.NET MVC application. The application is documented using `markdown` files in each folder, where there is explanation necessary. There are several important parts that this project highlights:

* The difference between DTO and domain entities
* The usage of DTO and Request objects
* The location of the client and how the client communicates with the backend

## A CRM system
This boilerplate implementation will be a simple Customer Relationship Management (CRM) System. A system like this enables a company to keep track of all of their customers.

## Ressources
There are several libraries used in this solution:

[FluentValidation](https://docs.fluentvalidation.net/en/latest/) NuGet package to validate business logic. Examples of this can be seen in the `Request` classes in the `CRM.Domain` project.

[Ensure.That](https://www.nuget.org/packages/Ensure.That/) NuGet package that will help to make clear and easy to read guard clauses. This can be seen in the entities in the `CRM.Domain` project.

[AutoMapper](https://docs.automapper.org/en/stable/index.html) NuGet package to help with mapping between objects/entities. This can be seen in the `Facade` classes in the `CRM.BLL` project.

[Dapper](https://github.com/DapperLib/Dapper) NuGet package with the lightweight ORM Dapper. Dapper is used to provide helper methods for querying the database.

[Serilog](https://serilog.net/) Simple .NET logging with many options. In this project it is configured to log to SeQ

[SeQ](https://datalust.co/seq) Centralized logging application that makes logging data easily available for search. It is recommended to use the Docker SeQ image to run SeQ in a container during development [Docker datalust/seq](https://hub.docker.com/r/datalust/seq)
