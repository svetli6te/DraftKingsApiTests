Feature: BookLibrary

Background: 
	Given Valid Authorization token is generated

Scenario: Get Books
	When GET request to /Books with valid Authorisation header is sent
	Then The response code should be 200

Scenario: Get Books - Unauthorized
	When GET request to /Books with no Authorisation header is sent
	Then The response code should be 401

Scenario: Create Book
	When POST request to /Books is sent
	Then The response code should be 200

Scenario: Create Book without title
	When POST request to /Books with missing title is sent
	Then The response code should be 400

Scenario: Get Book
	When GET request to /Books with valid Authorisation header is sent
	And GET request to /Books/BookId is sent
	Then The response code should be 200

Scenario: Get Book - invalid id
	When GET request to /Books/BookId with invalid id is sent
	Then The response code should be 500

Scenario: Put Book - first element in Books
	When GET request to /Books with valid Authorisation header is sent
	And PUT request to /Books for the first book is sent
	Then The response code should be 200

Scenario: Put Book - bad request
	When GET request to /Books with valid Authorisation header is sent
	And invalid PUT request to /Books for the first book is sent
	Then The response code should be 400

Scenario: Delete Book - first element in Books
	When GET request to /Books with valid Authorisation header is sent
	And Delete request to /Books for the first book is sent
	Then The response code should be 200

Scenario: Delete Book - Bad request
	When GET request to /Books with valid Authorisation header is sent
	And Invalid Delete request to /Books for the first book is sent
	Then The response code should be 400