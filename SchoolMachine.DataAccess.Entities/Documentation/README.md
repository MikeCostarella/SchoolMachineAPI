# SchoolMachine.DataAccess.Entities

This project is responsible for the creation and maintenance of the code first database of the project.

## Database Creation

* Create database named SchoolMachine

## Database Recreation

* Clean up existing database
  * Drop and recreate the database
  * Or run the SQL script named CleanDatabase.sql in the database query manager
* Delete Migrations folder in this project
  * This will restart the database creation schema from the beginning
* From package manager console in Visual Studio
  * add-migration Initial
  * update-database -verbose

## Data Seeding

* Currently the project is set up to delete the database and recreate each time SchoolMachineAPI project is run.
  * See SchoolMachine.API.Extensions.ApplicationBuilderExtensions.DeleteAndRecreateDatabase()
  * Currently called in Startup.cs of the ShoolMachineAPI project for greenfield development.
    * NOTE: STRONG MEDICINE.
    * Make sure to remove this or turn it by application setting prior to deployment to production.