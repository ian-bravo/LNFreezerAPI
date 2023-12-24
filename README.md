## [Liquid Nitrogen Freezer Organizer API](#ln-freezer-api)

### By _**Ian Bravo**_

### _This RESTful web API is designed for a Liquid Nitrogen Freezer Organizer Application._

## Technologies Used

* _C# 10.0_
* _.Net 6.0_
* _ASP.NET Core 6.0_
* _Entity Framework Core 6.0_
* _MySQL 8.0_
* _Postman_
* _Swashbuckle.AspNetCore 6.2_

## Description

This RESTful API will allow for the creation of a freezer management system. This web API has many different endpoints as shown in the API's README (https://github.com/ian-bravo/LNFreezerAPI). User Authentication and Authorization implementation is planned.

## Setup/Installation Requirements

Installing/Configuring MySQL:

1. Follow the instructions on this <a href="https://full-time-pre-october.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql">page</a> for installing and configuring MySQL.

Installing Postman:
1. Follow the instructions <a href="https://www.postman.com/downloads/">here,</a> for installing Postman to use for API calling.

Installing dotnet-ef:
1. Run the following command to globally install dotnet-ef tools which will allow you to create migrations and create databases:    
   `$ dotnet tool install --global dotnet-ef --version 6.0.0`

Cloning the API Repo:
1. Open the terminal.
2. Change your directory to where you would want the cloned directory.
3. Input the following command into your terminal:  
 `$ git clone https://github.com/ian-bravo/LNFreezerAPI`
4. Using the terminal, navigate to the production directory: "AnimalShelterApi" and create a new file called appsettings.json
5. Within appsettings.json, put in the following code while also replacing the following values with your own values as shown in the code snippet below:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```
* [YOUR-USERNAME-HERE] with your username
* [YOUR-PASSWORD-HERE] with your password
* [YOUR-DB-NAME] with the name of your database

Generating the database:
1. Navigate to the project's production directory "LNFreezerAPI" using the terminal.
2. Run the following command to update the database:    
  `$ dotnet ef database update`

Launch the API:
1. Navigate to the project's production directory "LNFreezerAPI" using the terminal.
2. Run the following command to grant access for the browser/Postman to use the API:      
  `$ dotnet run`
