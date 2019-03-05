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

