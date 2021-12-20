# Nultien - The Shop App
There's a ShopService that has the ability to display, order and sell the items.  
Client code orders and sells items and also displays those that he has been able to find and those that he hasn't been able to find in the Shop.

## Description

This is a code refactor tech challenge created by the Nultien company for interview purposes. 
The idea is to refactor original code and create a service using best pratices. Created service must  have **good test coverage** and **error handling**.
Beside original functionality that was required, few others have been added.
Solution was expanded so now it suports adding/editing customers and adding or editing inventories and article quantity.
Solution was switched to REST API technology, so it can easily be connected to some front end, or other service.

## Tech stack

- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) - WebApi application

## Dependencies

- [Mapster](https://github.com/MapsterMapper/Mapster) is used as auto mapper.
- [MapsterDependecyInjection](https://www.nuget.org/packages/Mapster.DependencyInjection/1.0.0) is used for auto mapper.
- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/5.0.12) is used for database operations.
- [xUnit](https://www.nuget.org/packages/xunit/2.4.1) is used for unit testing.
- [Moq](https://www.nuget.org/packages/Moq/4.16.1) is used for unit testing.
- [Swashbuckle.AspNetCore] (https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.6.3) is used for Swagger.

## Start

### SQL Server
- An instance of sql server is required for the project to work. 
- On project startup small database will be created.

### Visual Studio 2019/2022
- In Microsoft Visual Studio 2019/2022 set NultienShop.REST as a startup project.
- Open appsettings.json and change DefaultConnection to your database connection string.
- Press f5 to start the project.
- After startup Swagger should appear in default browser, and project is ready for use.

## Tests

- Unit tests

