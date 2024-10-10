using bugtracker.Models;
using System;
using System.Linq;

namespace bugtracker.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BugtrackerContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                if (context.Users.Count(u => string.Equals(u.AuthenticatedId, string.Empty)) > 0)
                {
                    InitAuthenticatedIds(context);
                }
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{AuthenticatedId="auth0|6707b877a55272a321ea6c92", UserName="Nino Olivetto",Email="nino@hotmail.com", Role=UserRole.ADMIN, Type=UserType.Regular},
                new User{AuthenticatedId="auth0|6707b8254c1b3061f5ecd9e9", UserName="Meredith Alonso",Email="alonso98@hotmail.com", Role=UserRole.ADMIN, Type=UserType.Regular},
                new User{AuthenticatedId="auth0|6707b8084c1b3061f5ecd9dc", UserName="Arturo Anand",Email="aanand@msn.com", Role=UserRole.PM, Type=UserType.Regular},
                new User{AuthenticatedId="auth0|6707b7e400a8a31d1713efcb", UserName="Laura Norman",Email="l.norman@gmail.com", Role=UserRole.PM, Type=UserType.Regular},
                new User{AuthenticatedId="auth0|6707b7c300a56e0a21ec190a", UserName="Carson Alexander",Email="carson56@outlook.com", Role=UserRole.DEV, Type=UserType.Regular},
                new User{AuthenticatedId="auth0|6707b76e4c1b3061f5ecd994", UserName="Gytis Barzdukas",Email="gytis.barzdukas@yahoo.com", Role=UserRole.DEV, Type=UserType.Regular},
                new User{AuthenticatedId="auth0|6707b739a55272a321ea6bf6", UserName="Yan Li",Email="yan.li98@hotmail.com", Role=UserRole.DEV, Type=UserType.Regular},
                new User{AuthenticatedId="auth0|6707b6c878d9c8f2252cd5b9", UserName="Peggy Justice",Email="peggy@gmail.com", Role=UserRole.DEV, Type=UserType.Regular},
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();


            var projects = new Project[]
            {
                new Project{Title="Messenger App", Description="Create a Messenger App to enhance Clinet Support"},
                new Project{Title="Testing plateforme", Description="Create a Testing plateforme and perform processes"},
                new Project{Title="Bugtracker", Description="Create a Bugtracker for indepth understanding of ASP.NET and C#"},
            };
            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();

            var tickets = new Ticket[]
            {
            new Ticket{ProjectID=1, Title="Design Login Button",Description="Manage Auth0 librairies and customization possibilities", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2022-04-01"), Status=TicketStatus.Waiting, Priority=TicketPriority.High},
            new Ticket{ProjectID=1, Title="Deploy new Attachment feature", Description="Deploy new feature ready in development", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2022-03-01"), Status=TicketStatus.InProgress, Priority=TicketPriority.Low},
            new Ticket{ProjectID=1, Title="Seed the database", Description="Create info line by line to start worjing with databases", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2022-12-01"), Status=TicketStatus.Finished, Priority=TicketPriority.Low},
            new Ticket{ProjectID=1, Title="Customize Login features", Description="Develop the UX that enables 'DEMO' accounts", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2022-01-09"), Status=TicketStatus.InProgress, Priority=TicketPriority.Medium},
            new Ticket{ProjectID=1, Title="Deploy on Azure", Description="Use Azure services for free deployements", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2022-07-17"), Status=TicketStatus.Stuck, Priority=TicketPriority.Medium},
            new Ticket{ProjectID=1, Title="Develop Comments feature", Description="Make Comments to Tickets possible", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2022-03-13"), Status=TicketStatus.InProgress, Priority=TicketPriority.Low},
            new Ticket{ProjectID=1, Title="Develop Demo User feature", Description="Develop the Logic that enables 'DEMO' accounts", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-11-12"), Status=TicketStatus.InProgress, Priority=TicketPriority.High},
            new Ticket{ProjectID=2, Title="Initialze project", Description="Set up development environment", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-04"), Status=TicketStatus.Stuck, Priority=TicketPriority.High},
            new Ticket{ProjectID=2, Title="Write an SRS", Description="Specific Software Requirements", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-25"), Status=TicketStatus.InProgress, Priority=TicketPriority.High},
            new Ticket{ProjectID=3, Title="Initialze project", Description="Set up development environment", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-02-01"), Status=TicketStatus.Waiting, Priority=TicketPriority.Low},
            new Ticket{ProjectID=3, Title="Write an SRS", Description="Specific Software Requirements", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-06-01"), Status=TicketStatus.InProgress, Priority=TicketPriority.High},
            new Ticket{ProjectID=3, Title="Design the architecture of the system", Description="Choose the backend architecture to handle large scale uses", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-01"), Status=TicketStatus.Waiting, Priority=TicketPriority.High},
            };
            foreach (Ticket c in tickets)
            {
                context.Tickets.Add(c);
            }
            context.SaveChanges();

            var projectUsers = new ProjectAssignment[] {
                new ProjectAssignment{
                    UserID = users.Single(u => u.UserName == "Nino Olivetto").Id,
                    ProjectID = projects.Single(p => p.Title == "Testing plateforme").Id
                },
                new ProjectAssignment{
                    UserID = users.Single(u => u.UserName == "Meredith Alonso").Id,
                    ProjectID = projects.Single(p => p.Title == "Messenger App").Id
                },
                new ProjectAssignment{
                    UserID = users.Single(u => u.UserName == "Arturo Anand").Id,
                    ProjectID = projects.Single(p => p.Title == "Testing plateforme").Id
                },
                new ProjectAssignment{
                    UserID = users.Single(u => u.UserName == "Laura Norman").Id,
                    ProjectID = projects.Single(p => p.Title == "Messenger App").Id
                },
                new ProjectAssignment{
                    UserID = users.Single(u => u.UserName == "Carson Alexander").Id,
                    ProjectID = projects.Single(p => p.Title == "Testing plateforme").Id
                },
                new ProjectAssignment{
                    UserID = users.Single(u => u.UserName == "Gytis Barzdukas").Id,
                    ProjectID = projects.Single(p => p.Title == "Testing plateforme").Id
                },
                new ProjectAssignment{
                    UserID = users.Single(u => u.UserName == "Yan Li").Id,
                    ProjectID = projects.Single(p => p.Title == "Messenger App").Id
                },
                new ProjectAssignment{
                    UserID = users.Single(u => u.UserName == "Peggy Justice").Id,
                    ProjectID = projects.Single(p => p.Title == "Messenger App").Id
                },
            };

            foreach (ProjectAssignment pa in projectUsers)
            {
                context.ProjectAssignments.Add(pa);
            }
            context.SaveChanges();

            var ticketUser = new TicketAssignment[]
            {
                new TicketAssignment{
                    UserID = users.Single(u => u.UserName == "Arturo Anand").Id,
                    TicketID = 8,
                },
                new TicketAssignment{
                    UserID = users.Single(u => u.UserName == "Carson Alexander").Id,
                    TicketID = 9,
                },
                new TicketAssignment{
                    UserID = users.Single(u => u.UserName == "Laura Norman").Id,
                    TicketID = 10,
                },
                new TicketAssignment{
                    UserID = users.Single(u => u.UserName == "Yan Li").Id,
                    TicketID = 11,
                },
                new TicketAssignment{
                    UserID = users.Single(u => u.UserName == "Peggy Justice").Id,
                    TicketID = 12,
                },
            };

            foreach (TicketAssignment ta in ticketUser)
            {
                context.TicketAssignments.Add(ta);
            }
            context.SaveChanges();

        }

        private static void InitAuthenticatedIds(BugtrackerContext context)
        {
            var users = context.Users.ToList();
            // users.Single(u => u.UserName == "Nino Olivetto").AuthenticatedId = "auth0|6707b877a55272a321ea6c92";
            // users.Single(u => u.UserName == "Meredith Alonso").AuthenticatedId = "auth0|6707b8254c1b3061f5ecd9e9";
            // users.Single(u => u.UserName == "Arturo Anand").AuthenticatedId = "auth0|6707b8084c1b3061f5ecd9dc";
            // users.Single(u => u.UserName == "Laura Norman").AuthenticatedId = "auth0|6707b7e400a8a31d1713efcb";
            // var user = users.Single(u => u.UserName == "Carson Alexander 2").AuthenticatedId = "auth0|6707b7c300a56e0a21ec190a";
            // users.Single(u => u.UserName == "Gytis Barzdukas").AuthenticatedId = "auth0|6707b76e4c1b3061f5ecd994";
            // users.Single(u => u.UserName == "Yan Li").AuthenticatedId = "auth0|6707b739a55272a321ea6bf6";
            // users.Single(u => u.UserName == "Peggy Justice").AuthenticatedId = "auth0|6707b6c878d9c8f2252cd5b9";
            //
            // context.UpdateRange(user);
            //
            // context.SaveChanges();
        }
    }
}