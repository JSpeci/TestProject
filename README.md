# Test Project
The test project is a simple web application that consists from two screens.

* Main screen = filter + person list
* Person detail = form

Mockups can be found in _mockups.pdf_ included in this repository.

## Entities

*Person*
* Id: Guid
* FirstName: string
* LastName: string
* Groups: List(Group)

*Group*

* Id: Guid
* Name: string

The entities doesn't need to be persisted. They can be kept in static lists or something similar.

## Project structure
- Persistance layer - EntityFramework Core which use MS SQL database
- Server App - MVC web application 
	- this application include only one page that contains code which bootstrap the client app
	- this application containst REST API 
		- GET /api/person - return list of people
		- GET /api/person/id - return single person
		- POST /api/person (JSON body) - saves the person
- Client App - angular1.x (! old angular)
	- makes the REST API requests to the server

## Technologies

* ASP.NET Core (https://docs.microsoft.com/en-us/aspnet/core/)
* Entity Framework Core (https://docs.microsoft.com/en-us/ef/core/)
* Client js Angular 1.x (https://angularjs.org/)