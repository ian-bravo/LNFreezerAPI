## [Liquid Nitrogen Freezer Organizer API](#ln-freezer-api)

#### By _**Ian Bravo**_

### _This RESTful web API is designed for a Liquid Nitrogen Freezer Organizer Application._

## Table of Contents
* [Liquid Nitrogen Freezer Organizer API](#liquid-nitrogen-freezer-organizer-api)
* [Technologies Used](#technologies-used)
* [Description](#description)
* [Setup and Installation Requirements](#setup-and-installation-requirements)
* [API Documentation](#api-documentation)
  * [Freezers](#freezers)
  * [Racks](#racks)
  * [Boxes](#boxes)
  * [Specimens](#specimens)
* [Known Bugs](#known-bugs)
* [License](#license)

## [Technologies Used](#technologies-used)

* _C# 10.0_
* _.Net 6.0_
* _ASP.NET Core 6.0_
* _Entity Framework Core 6.0_
* _MySQL 8.0_
* _Postman_
* _Swashbuckle.AspNetCore 6.2_

## [Description](#description)

This RESTful API will allow for the creation of a freezer management system. This web API has many different endpoints as shown in the API's README (https://github.com/ian-bravo/LNFreezerAPI). User Authentication and Authorization implementation is planned.

## [Setup and Installation Requirements](#setup-and-installation-requirements)


Installing/Configuring MySQL:

1. Follow the instructions on this <a href="https://full-time-pre-october.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql">page</a> for installing and configuring MySQL.

Installing Postman:
1. Follow the instructions <a href="https://www.postman.com/downloads/">here,</a> for installing Postman to use for API calling.

Installing dotnet-ef:
1. Run the following command to globally install dotnet-ef tools which will allow you to create migrations and create databases:    
```
$ dotnet tool install --global dotnet-ef --version 6.0.0
```


Cloning the API Repo:
1. Open the terminal.
2. Change your directory to where you would want the cloned directory.
3. Input the following command into your terminal:  
```
$ git clone https://github.com/ian-bravo/LNFreezerAPI
```

4. Using the terminal, navigate to the production directory: "LNFreezerAPI" and create a new file called appsettings.json
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
```
$ dotnet ef database update
``` 

Launch the API:
1. Navigate to the project's production directory "LNFreezerAPI" using the terminal.
2. Run the following command to grant access for the browser/Postman to use the API:      
```
$ dotnet run
```

## [API Documentation](#api-documentation)
Explore the API endpoints via Postman.

### Endpoints:
Base URL: 
```
https://localhost:5000
```
----------------------------------------------------------------

### HTTP Request Structure:
```
GET /api/{component}
POST /api/{component}
GET /api/{component}/{id}
PUT /api/{component}/{id}
DELETE /api/{component}/{id}
```
----------------------------------------------------------------

## [Freezers](#freezers)

#### GET Http Requests:
```
GET http://localhost:5000/api/freezers
GET http://localhost:5000/api/freezers/{id}
```

#### Optional GET Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| freezerNum | int | none | false | Return matches by freezer number.

#### Example GET query:
```
http://localhost:5000/api/freezers
```

#### Sample GET JSON Response:
```json
{
    "freezerId": 1,
    "freezerNum": 1
},
{
    "freezerId": 2,
    "freezerNum": 2
},
{
    "freezerId": 3,
    "freezerNum": 3
}
```
----------------------------------------------------------------
#### POST Http Requests:
```
POST http://localhost:5000/api/freezers
```

#### POST Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| freezerNum | int | none | true | Creates a freezer number.

#### Example POST:
```
http://localhost:5000/api/freezers/
```
```json
{
    "freezerNum": 4,
}
```

#### Sample POST JSON Response:
```json
{
    "freezerId": 4,
    "freezerNum": 4
}
```
----------------------------------------------------------------
#### PUT Http Requests:
```
PUT http://localhost:5000/api/freezers/{id}
```

#### PUT Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| freezerId | int | none | true | Assigned Id to freezer.
| freezerNum | int | none | true | Updates the freezer number.

#### Example PUT request:
```
http://localhost:5000/api/freezers/4/
```
```json
{
    "freezerId": 4,
    "freezerNum": 7
}
```

#### Sample PUT Response:
```json
204 No Content. The server successfully processed the request, but is not returning any content.
```

----------------------------------------------------------------

#### DELETE Http Requests:
```
DELETE http://localhost:5000/api/freezers/{id}
```

#### DELETE Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| freezerId | int | none | true | Assigned Id to freezer.

#### Example DELETE request:
```
http://localhost:5000/api/freezers/4/
```

#### Sample DELETE Response:
```json
204 No Content. The server successfully processed the request, but is not returning any content.
```

----------------------------------------------------------------

## [Racks](#racks)

#### GET Http Requests:
```
GET http://localhost:5000/api/racks
GET http://localhost:5000/api/racks/{id}
```

#### Optional GET Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| rackNum | int | none | false | Return matches by rack number.
| freezerId | int | none | false | Returns matches by rack's freezer Id.

#### Example GET query:
```
http://localhost:5000/api/racks
```

#### Sample GET JSON Response:
```json
{
    "rackId": 1,
    "rackNum": 1,
    "freezerId": 1
},
{
    "rackId": 6,
    "rackNum": 6,
    "freezerId": 1
},
{
    "rackId": 10,
    "rackNum": 30,
    "freezerId": 7
}
```
----------------------------------------------------------------
#### POST Http Requests:
```
POST http://localhost:5000/api/racks
```

#### POST Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| rackNum | int | none | true | Creates a rack number.
| freezerId | int | none | true | Creates a rack's freezer Id.

#### Example POST:
```
http://localhost:5000/api/racks/
```
```json
{
    "rackNum": 4,
    "freezerId": 8
}
```

#### Sample POST JSON Response:
```json
{
    "rackId": 4,
    "rackNum": 4,
    "freezerId": 8
}
```
----------------------------------------------------------------
#### PUT Http Requests:
```
PUT http://localhost:5000/api/racks/{id}
```

#### PUT Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| rackId | int | none | true | Assigned Id to rack.
| rackNum | int | none | true | Updates the rack number.
| freezerId | int | none | true | Updates the rack's freezer Id.

#### Example PUT request:
```
http://localhost:5000/api/racks/4/
```
```json
{
    "rackId": 4,
    "rackNum": 4,
    "freezerId": 10
}
```

#### Sample PUT Response:
```json
204 No Content. The server successfully processed the request, but is not returning any content.
```

----------------------------------------------------------------

#### DELETE Http Requests:
```
DELETE http://localhost:5000/api/racks/{id}
```

#### DELETE Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| rackId | int | none | true | Assigned Id to rack.

#### Example DELETE request:
```
http://localhost:5000/api/racks/4/
```

#### Sample DELETE Response:
```json
204 No Content. The server successfully processed the request, but is not returning any content.
```

----------------------------------------------------------------

## [Boxes](#boxes)

#### GET Http Requests:
```
GET http://localhost:5000/api/boxes
GET http://localhost:5000/api/boxes/{id}
```

#### Optional GET Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| boxAlpha | string | none | false | Return matches by box number.
| rackId | int | none | false | Returns matches by boxes's rack Id.

#### Example GET query:
```
http://localhost:5000/api/boxes
```

#### Sample GET JSON Response:
```json
{
    "boxId": 1,
    "boxAlpha": "A",
    "rackId": 1
},
{
    "boxId": 20,
    "boxAlpha": "A",
    "rackId": 45
},
{
    "boxId": 25,
    "boxAlpha": "C",
    "rackId": 3
}
```
----------------------------------------------------------------
#### POST Http Requests:
```
POST http://localhost:5000/api/boxes
```

#### POST Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| boxAlpha | int | none | true | Creates a box number.
| rackId | int | none | true | Creates a boxes's rack Id.

#### Example POST:
```
http://localhost:5000/api/boxes/
```
```json
{
    "boxAlpha": "D",
    "rackId": 8
}
```

#### Sample POST JSON Response:
```json
{
    "boxId": 30,
    "boxAlpha": "D",
    "rackId": 8
}
```
----------------------------------------------------------------

#### PUT Http Requests:
```
PUT http://localhost:5000/api/boxes/{id}
```

#### PUT Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| boxId | int | none | true | Assigned Id to box.
| boxAlpha | int | none | true | Updates the box number.
| rackId | int | none | true | Updates the boxes's rack Id.

#### Example PUT request:
```
http://localhost:5000/api/boxes/30/
```
```json
{
    "boxId": 30,
    "boxAlpha": "E",
    "rackId": 10
}
```

#### Sample PUT Response:
```json
204 No Content. The server successfully processed the request, but is not returning any content.
```

----------------------------------------------------------------

#### DELETE Http Requests:
```
DELETE http://localhost:5000/api/boxes/{id}
```

#### DELETE Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| boxId | int | none | true | Assigned Id to box.

#### Example DELETE request:
```
http://localhost:5000/api/boxes/30/
```

#### Sample DELETE Response:
```json
204 No Content. The server successfully processed the request, but is not returning any content.
```

----------------------------------------------------------------

## [Specimens](#specimens)

#### GET Http Requests:
```
GET http://localhost:5000/api/specimens
GET http://localhost:5000/api/specimens/{id}
```

#### Optional GET Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| specimenNum | int | none | false | Return matches by specimen number.
| cohort | string | none | false | Returns matches by cohort.
| nHPNum | int | none | false | Return matches by NHP number.
| date | string | none | false | Return matches by date.
| tissue | string | none | false | Return matches by tissue.
| quantity | string | none | false | Return matches quantity.
| boxId | int | none | false | Return matches by specimen's box ID.


#### Example GET query:
```
http://localhost:5000/api/specimens
```

#### Sample GET JSON Response:
```json
{
    "specimenId": 1,
    "specimenNum": 1,
    "cohort": "PC475",
    "nhpNum": 32283,
    "date": "051422",
    "tissue": "BM",
    "quantity": "2e6",
    "boxId": 1
},
{
    "specimenId": 4,
    "specimenNum": 4,
    "cohort": "PC475",
    "nhpNum": 33887,
    "date": "052122",
    "tissue": "PBMC",
    "quantity": "8e6",
    "boxId": 4
},
{
    "specimenId": 10,
    "specimenNum": 10,
    "cohort": "PC498",
    "nhpNum": 29396,
    "date": "091722",
    "tissue": "PBMC",
    "quantity": "15e6",
    "boxId": 20
}
```
----------------------------------------------------------------

#### POST Http Requests:
```
POST http://localhost:5000/api/specimens
```

#### POST Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| specimenNum | int | none | true | Creates specimen number.
| cohort | string | none | true | Creates cohort.
| nHPNum | int | none | true | Creates NHP number.
| date | string | none | true | Creates date.
| tissue | string | none | true | Creates tissue.
| quantity | string | none | true | Creates quantity.
| boxId | int | none | true | Creates specimen's box ID.

#### Example POST:
```
http://localhost:5000/api/specimens/
```
```json
{
    "specimenNum": 1,
    "cohort": "PC521",
    "nhpNum": 34331,
    "date": "062123",
    "tissue": "P.LN",
    "quantity": "8e6",
    "boxId": 39
}
```

#### Sample POST JSON Response:
```json
{
    "specimenId": 82,
    "specimenNum": 1,
    "cohort": "PC521",
    "nhpNum": 34331,
    "date": "062123",
    "tissue": "P.LN",
    "quantity": "8e6",
    "boxId": 39
}
```
----------------------------------------------------------------
#### PUT Http Requests:
```
PUT http://localhost:5000/api/specimens/{id}
```

#### PUT Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| specimenId | int | none | true | Assigned ID to specimen.
| specimenNum | int | none | true | Updates specimen number.
| cohort | string | none | true | Updates cohort.
| nHPNum | int | none | true | Updates NHP number.
| date | string | none | true | Updates date.
| tissue | string | none | true | Updates tissue.
| quantity | string | none | true | Updates quantity.
| boxId | int | none | true | Updates specimen's box ID.

#### Example PUT request:
```
http://localhost:5000/api/specimens/82/
```
```json
{
    "specimenId": 82,
    "specimenNum": 30,
    "cohort": "PC521",
    "nhpNum": 34331,
    "date": "062123",
    "tissue": "P.LN",
    "quantity": "8e6",
    "boxId": 39
}
```

#### Sample PUT Response:
```json
204 No Content. The server successfully processed the request, but is not returning any content.
```

----------------------------------------------------------------

#### DELETE Http Requests:
```
DELETE http://localhost:5000/api/specimens/{id}
```

#### DELETE Path Parameters:
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| specimenId | int | none | true | Assigned Id to specimen.

#### Example DELETE request:
```
http://localhost:5000/api/specimens/82/
```

#### Sample DELETE Response:
```json
204 No Content. The server successfully processed the request, but is not returning any content.
```

----------------------------------------------------------------

## [Known Bugs](#known-bugs)
* _No known bugs_

## [License](#license)

MIT License  

Copyright (c) 23-Dec-2023 Ian Bravo  

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:  

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.  

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.



_For questions or concerns, please email me at bravo.ian@gmail.com_
