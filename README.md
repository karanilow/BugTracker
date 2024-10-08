# Project management tool "BugTracker"
This tool allows you to create, assign and track tasks or issues during the lifecycle of a project. 

## Table of Contents
- [Installation](#installation)
- [Features](#features)

## Installation
1. Ensure you have the latest .NET 8 SDK installed. (Windows Winget: `winget install dotnet-sdk-8`)
2. Clone the repository:
```bash
 git clone https://github.com/karanilow/BugTracker.git
```
3. Set the `connexion strings` for the SQLlite database or your favorite Database, and the Auth0 details of your account in the `appsettings.json` file. Visit the [Auth0 website](https://auth0.com/) for more informations.

4. Run the application in Visual Studio or use `dotnet run` in the `BugTracker` folder.

![Image of the Home screeen](Images/Home.png)

5. Create an account and sign in

![Image of the Login](Images/Login.png)

![Image of the Home signed in](Images/Home_SignIn.png)

![Image of the Dashboard](Images/Dashboard.png)

## Features

### Current features available 
- Create , update and list Projects. 
- Create, update and list Tickets in a Project.
- Monitor Tickets in a Project with the Dashboard.
- Navigate from the Dashboard to : Important Tickets overdue, Tickets stuck, Tickets in progress.  

### Backlog 
#### Must Have
- User management : CRUD, Ticket Assignement.
- Role management : User and Admin.
- Add a Ticket type to distinguish Bogue and Tasks.
  
#### Nice to Have
- On the dashboard, change the "Important ticket Overdue" card if the number of tickets > 0.
- On the dashboard, add an over effect to precise the user that each card is a link.
- On the dashboard of an empty project, add a link to create a new ticket.
- Add a creation date, an opened date and a complet date for each Ticket. Determine a Solving Time propertie from these dates.
- Add a graph on the dashboard of Average solving time over the past 3 months.
- Add other search criteria to the Ticket list screen : Type, date, status, User.
