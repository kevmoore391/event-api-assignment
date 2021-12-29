## Event API Assignment

### Features
- This is a restful api service built on the .NET platform utilizing the C# programming language.
- Using the Fluent Scheduler library, the application routinely fetches event data from two public event APIs, Ticketmaster and SeatGeek.
- Event data from the APIs are stored as a common entity type (Event) in an SQL database hosted on azure.
- The application provides a number of restful API endpoints which can be utilized to access the unified event data and to manipulate it where required.
- This app can be accessed by building locally via Visual Studio. Hit Ctrl + F5 to run and access the app via https://localhost:7207/swagger/index.html
- As the app is also hosted on azure, and can be accessed via:
https://event-api-assignment.azurewebsites.net/swagger/index.html
- Both local and hosted versions utilize the same database connection, so it is easy to test from either version.
- While running locally, we can see some print outs within the console, emphasizing that the schedule is kicking off the tasks as expected and finishing after the public api's have been engaged for further event data.

### Considerations Made:
- The connection strings should be moved to a secret vault for security purposes. The azure vault is not available on a free azure account so the connection strings will stay in the config file for the purpose of this assignment.
- I wanted it to be easy to connect to a database locally, without having to run mysql or postgres locally. Azure sql databases was very quick to setup and was the best option to make this possible for the assignment.
- Because the hosted SQL database can be accessed by a loccaly run version, I had to configure the database wirewall to allow all connections. Outside of this assignment, this would not be ideal, and specific ip addresses would be specified.
- As Ticketmaster and SeatGeek both offer a vast choice of api's, I chose simple examples for the purpose of this assignment.
 - For Ticketmaster, im using thier /event?StateCode=NY endpoint.
 - For SeatGeek im using thier /events?venue.state=NY endpoint.
 - This could be further expanded to cycle to a list of state codes or to attempt to search via specific performer or venue.
 - Both Apis require a api token which are stored in the  App.Config file for this assignment.
