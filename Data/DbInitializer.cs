using bugtracker.Models;
using System;
using System.Linq;

namespace bugtracker.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BugtrackerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{UserName="Nino Olivetto",Role=UserRole.ADMIN, Type=UserType.Regular},
            new User{UserName="Meredith Alonso",Role=UserRole.ADMIN, Type=UserType.Regular},
            new User{UserName="Arturo Anand",Role=UserRole.PM, Type=UserType.Regular},
            new User{UserName="Laura Norman",Role=UserRole.PM, Type=UserType.Regular},
            new User{UserName="Carson Alexander",Role=UserRole.DEV, Type=UserType.Regular},
            new User{UserName="Gytis Barzdukas",Role=UserRole.DEV, Type=UserType.Regular},
            new User{UserName="Yan Li",Role=UserRole.DEV, Type=UserType.Regular},
            new User{UserName="Peggy Justice",Role=UserRole.DEV, Type=UserType.Regular},
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();


            var projects = new Project[]
                        {
                new Project{Title="Bugtracker", Description="Create a Bugtracker for indepth understanding of ASP.NET and C#"}
                        };
            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();

            var ticketInfos = new TicketInfo[]
            {
                new TicketInfo{SubmittedByUserID=3, AssignedToUserID=5, Description="Manage Auth0 librairies and customization possibilities", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-01")},
                new TicketInfo{SubmittedByUserID=3, AssignedToUserID=6, Description="Deploy new feature ready in development", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-01")},
                new TicketInfo{SubmittedByUserID=4, AssignedToUserID=7, Description="Create info line by line to start worjing with databases", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-01")},
                new TicketInfo{SubmittedByUserID=4, AssignedToUserID=8, Description="Develop the UX that enables 'DEMO' accounts", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-01")},
                new TicketInfo{SubmittedByUserID=4, AssignedToUserID=5, Description="Use Azure services for free deployements", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-01")},
                new TicketInfo{SubmittedByUserID=4, AssignedToUserID=6, Description="Make Comments to Tickets possible", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-01")},
                new TicketInfo{SubmittedByUserID=3, AssignedToUserID=8, Description="Develop the Logic that enables 'DEMO' accounts", CreatedOn=DateTime.Parse("2021-09-01"), UpdatedOn=DateTime.Parse("2021-09-01"), FinishedOn=null, DueOn=DateTime.Parse("2021-12-01")},
            };
            foreach (TicketInfo t in ticketInfos)
            {
                context.TicketInfos.Add(t);
            }
            context.SaveChanges();


            var tickets = new Ticket[]
            {
            new Ticket{ProjectID=1, TicketInfoID=1, Title="Design Login Button", Status=TicketStatus.InProgress, Priority=TicketPriority.High},
            new Ticket{ProjectID=1, TicketInfoID=2, Title="Deploy new Attachment feature", Status=TicketStatus.InProgress, Priority=TicketPriority.High},
            new Ticket{ProjectID=1, TicketInfoID=3, Title="Seed the database", Status=TicketStatus.InProgress, Priority=TicketPriority.High},
            new Ticket{ProjectID=1, TicketInfoID=4, Title="Customize Login features", Status=TicketStatus.InProgress, Priority=TicketPriority.High},
            new Ticket{ProjectID=1, TicketInfoID=5, Title="Deploy on Azure", Status=TicketStatus.InProgress, Priority=TicketPriority.High},
            new Ticket{ProjectID=1, TicketInfoID=6, Title="Develop Comments feature", Status=TicketStatus.InProgress, Priority=TicketPriority.High},
            new Ticket{ProjectID=1, TicketInfoID=7, Title="Develop Demo User feature", Status=TicketStatus.InProgress, Priority=TicketPriority.High}
            };
            foreach (Ticket c in tickets)
            {
                context.Tickets.Add(c);
            }
            context.SaveChanges();

        }
    }
}