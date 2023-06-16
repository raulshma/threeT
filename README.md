# ThreeT

ThreeT is a web application designed to streamline work management and collaboration within organizations. It provides features for users to submit daily work status updates, track their work progress, and collaborate with teams. This README will guide you through the setup process for both the backend and frontend of the ThreeT project.

## Stack

The ThreeT project utilizes the following technologies:

### Backend
[![.NET](https://github.com/raulshma/threeT/actions/workflows/dotnet.yml/badge.svg)](https://github.com/raulshma/threeT/actions/workflows/dotnet.yml)
- [.NET 7](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7) - Backend framework
- [Next.js 13](https://nextjs.org/docs) - Frontend framework
- [Next Auth](https://next-auth.js.org/getting-started/example) - Authentication library for Next.js
- [Postgres](https://www.postgresql.org/download/) - Database
- Clean Architecture with Controller Service and Service Repository pattern - Backend structure
- [Mapperly](https://github.com/riok/mapperly) - Mapping library for entity-to-DTO and vice versa
- [Entity Framework Core](https://www.npgsql.org/efcore/) - Database ORM
- [OpenID Dict](https://github.com/openiddict/openiddict-core) - Using ASP.NET Identity Core for user authentications
- [Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-7.0) - ASP.NET Core authentication

### Frontend
![Vercel](https://img.shields.io/github/deployments/raulshma/threet/production?label=vercel&logo=vercel&logoColor=white)
- [Shadcn Components Library](https://ui.shadcn.com/docs) - UI component library
- [React Hook Forms](https://react-hook-form.com/) - Form validation library
- [Zod](https://github.com/colinhacks/zod) - Data schema and validation library

## Repository Structure

The ThreeT repository is structured as follows:

- **backend**: Contains the .NET projects for the API and authentication.
- **frontend**: Contains the Next.js frontend project.

## Prerequisites

Before setting up the ThreeT project, ensure you have the following installed:

- [Node.js](https://nodejs.org/en) (version 12 or higher)
- A code editor of your choice (e.g., [Visual Studio Code](https://code.visualstudio.com/download), [Visual Studio](https://visualstudio.microsoft.com/downloads/))
- [Git](https://git-scm.com/downloads)
- [.NET SDK 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Postgres](https://www.postgresql.org/download/) database (optional, as a dev database is provided, ask for connection string from @raulshma)

## Backend Setup

1. Clone the repository: `git clone https://github.com/raulshma/threeT.git`
2. Open your preferred editor or IDE and navigate to the `backend` directory.
3. You will find multiple projects in the solution. Two important projects are `ThreeTee.API` and `ThreeTee.Authentication`. The API project contains all the APIs used by the frontend, and the Authentication project handles the OpenID Dict server and user authentication.
4. Before running the projects, you need to add the connection string to the user-secrets manager of both the API and Authentication projects. The property names can be found in the `appsettings.json` file of each project. Add the connection string for either the local database or the dev database.
5. Set the `ThreeTee.Authentication` project as the startup project
6. Open the terminal and navigate to the `ThreeTee.Infrastructure.Persistence.Npgsql` project. Run the migration command to update the database schema:
   - If using the package manager console: `update-database`
   - If using the .NET CLI: `dotnet ef database update`
7. Run it using `dotnet run`. The backend should now be up and running.

## Frontend Setup

1. Inside the `frontend` directory, open the terminal and execute `npm install` to install the required dependencies.
2. Open the project in your preferred editor or IDE.
3. Create a new file in the root directory named `.env.local` and copy the contents from `.env.example`. Make any necessary changes to the configuration in the `.env.local` file, such as the authentication server URL and resource server URL.
4. Run the project using the `npm run dev` command.
5.

 You should now be able to access the ThreeT application at `http://localhost:3000`.
6. Upon accessing the application, you will land on the login page. Use the Single Sign-On (SSO) button to log in with the authentication server.

Congratulations! You have successfully set up the ThreeT project. Feel free to explore its features and functionalities to streamline your work management and collaboration within your organization.

## Additional Resources

- [.NET 7 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7)
- [Entity Framework Core 7.0 What's New](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/whatsnew)
- [Next.js Documentation](https://nextjs.org/docs)
- [Next Auth Getting Started](https://next-auth.js.org/getting-started/example)
- [Shadcn Components Library Documentation](https://ui.shadcn.com/docs)
- [Mapperly Repository](https://github.com/riok/mapperly)
- [Clean Architecture with .NET](https://medium.com/dotnet-hub/clean-architecture-with-dotnet-and-dotnet-core-aspnetcore-overview-introduction-getting-started-ec922e53bb97)
- [PostgreSQL](https://www.postgresql.org/about/)
- [Entity Framework Core Npgsql Provider](https://www.npgsql.org/efcore/)
- [GitHub Issues](https://github.com/features/issues) - For issue tracking and project management
- [Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-7.0&tabs=visual-studio)
