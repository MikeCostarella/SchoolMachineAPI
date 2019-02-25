# SchoolMachine

The SchoolMachine project .net core web API 2 project built upon EF Core.

The web services supports a small domain model that is based on Schools and Students.  Currently, this project is more focused on the architecture of .net core and ef core, than the depth of the domain.

The project is a work in progress, and many upgrades are planned.

Ultimately, it will be refactored into a collection of inter-related microservices host on Azure.

## Related Respositories

* SchoolMachineUIAngular
    * This project is a prototype UI built in Angular 7.

Known deficiencies and future goals for this solution:

* Add foregin constraint(s) on the model entities in the database context.
* Add cascading deletes perhaps.  (Needs discussion)
* Add more controller action method unit tests.
* Add automated and self hosted controller action integration tests.
* Add more coverage on the data repository integration tests project.
* Add a secret for the database conneciton string, or at least factor it into the appsettings.json file.
* Remove a hard file references inside of RestaurantReviews.API nlog.config.
* Remove 4 warnings in the repository layer because of asynchronous development issues.  (Need more research there.)
* Toughen up the TestInitialize method of the repository data integration tests
* Add CORS restricitons perhaps to the controller
* Add user authenitcation and authorization to the controller actions
* Add a base test class to factor duplicated behavior
* Refactor the services into microservice solutions
* Dockerize the solutions for Azure and AWS deployment


## Tools 

* Visual Stuido 2017 - Community Edition
* .Net Core 2.2
* EF Core 2+
* IIS Express
* NLog
* Swashbuckle/Swagger
* PostgresSQL (MSSQL is also included but not activated)
* AutoMapper
* MSTest
* Moq

## Setup

* Install Postgres SQL
  * set db passwords to trust mode for ease
* Check out the DataSeeder class to understand what data is applied upon the build of the database.
  * This seed data must be in place for the repository data integration tests to pass.
* Run the SchoolMachine.API project to bring up the Swagger Open API document in the browser.

## Services

* Domain Level Services
  * SchoolStudentRegistration
    * This is the controller that contains the public facing services
    * It is currently just a skeleton

* CRUD Services
  * School
  * Student
  * SchoolStudent (currently incomplete)

* Security (skeleton controller currently)
  * User