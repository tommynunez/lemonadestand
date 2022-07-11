# LemonadeStand

Lemonade Stand is the backend server project written in C# using the .net 6 framework.  Lemonade Stand provides endpoints utilizing HTTP protocol and Graphql via Hot Chocolate.  You can test the application in various ways first approach is with the already provided postman collection within this repo, second is swashbuckle for HTTP Protocol endpoints and third is hot chocolate playground for graphql.

## Installation

This application runs on the latest .NET 6 version with Hot Choloate, Entity Framework Core and few other dependencies.



## Running the application 

```node
git clone git@github.com:tommynunez/LemonadeStand.git

# navigate to the api project
cd LemonadeStand/LemonadeStand

# run migration
dotnet ef database update

#run application
dotnet run

#make sure whatever port number the application is listening on is the same for the [LemonadeStandUI repo](https://github.com/tommynunez/LemonadeStandUI) so the two can communicate

dotnet run
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5021
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Local
```
