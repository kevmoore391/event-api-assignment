## Event API Assignment
 
 ### How to run
 
- first clone down this repository:
  - git clone https://github.com/kevmoore391/event-api-assignment.git
- Open the project with visual studios and build the project
  - Hit Ctrl + F5 to run without debug and access the app via https://localhost:7207/swagger/index.html
- Alternatively you may access the application via Azure
  - https://event-api-assignment.azurewebsites.net/swagger/index.html

### Features
- This is a restful api service built on the .NET platform utilizing the C# programming language.
- Using the Fluent Scheduler library, the application routinely fetches event data from two public event APIs, Ticketmaster and SeatGeek.
  - https://fluentscheduler.github.io/
  - Fluent Scheduler Is initialized in the startup.cs file and calls upon a registry class (Model/ScheduleEventRoutine.cs) which outlines the rules of the schedule
    - For the assignment, I set a single instance of the schedule to run, after a 3 second delay, and to run every 60 seconds (would be changed for a real life setting)
  - The Schedule calls on a job class (Model/EventRoutineJob.cs) which executes the job we need done. We simply create an instance of the event service (Model/EventService.cs) and call the initial functions.
- Event data from the APIs via rest (Modal/Ticketmaster/TicketmasterClient.cs & Modal/SeatGeek/SeatGeek.cs) and stored as a common entity type (Model/Event.cs) in an SQL database hosted on azure.
- The application provides a number of restful API endpoints which can be utilized by an external source, to access the unified event data and to manipulate it where required.
  - GET /Event - Gets a list of all events stored in the DB
  - POST /Event - allows a user to manually save the new provided event to the DB
  - GET /Event/{id} - Fetches a specific event matching the id provided
  - PUT /Event/{id} - updates an event matching the provided id with the provided Event object
  - DELETE /Event/{id} - deletes an event from the db, matching the provided id
  - All Endpoints use input validation for the provided id paramater

- Both local and hosted versions utilize the same database connection, so it is easy to test from either version.
- While running locally, we can see some print outs within the console, emphasizing that the schedule is kicking off the tasks as expected and finishing after the public api's have been engaged for further event data.

### Considerations for enhancements:
- This app could be split up, if in a microservice architecture, the scheduled process could be one app while the controller could be is own app.
- The connection strings should be moved to a secret vault for security purposes. The azure vault is not available on a free azure account so the connection strings will stay in the config file for the purpose of this assignment.
- I wanted it to be easy to connect to a database locally, without having to run mysql or postgres locally. Azure sql databases was very quick to setup and was the best option to make this possible for the assignment. Since the hosted SQL database can be accessed by a loccaly run version, I had to configure the database wirewall to allow all connections. Outside of this assignment, this would not be ideal and specific ip addresses would be specified.
- As Ticketmaster and SeatGeek both offer a vast choice of api's, I chose simple examples for the purpose of this assignment.
  - For Ticketmaster, im using thier /event?StateCode=NY endpoint.
  - For SeatGeek im using thier /events?venue.state=NY endpoint.
  - This could be further expanded to cycle tthrough a list of state codes or to attempt to search via specific performer or venue.
  - Both Apis require an API token which are stored in the  App.Config file for this assignment.
- I created a test project to create unit tests for the Controller. However for the sake of the assignment i added the Test directory and the commented EventControllerTest file. All the tests pass. Further from this I would flesh out tests to use the endpoints rather than direct function names. I would also create tests for all other functionality and find a way to have them execute in the same project (rather than a referencing test project) and find a way to execute the tests on github when the branch is pushed.
- For security purposes the endpoints could be locked down to particular users or services within azure.
