# My-server

This project is the backend for the Task Management System, built using .NET, MartenDB, and PostgreSQL.

## Getting Started

Before you begin, ensure that you have the following software installed on your machine:

- .NET SDK (version 5.0 or later)
- PostgreSQL (version 12 or later)

### Installation

1. Clone the repository:
git clone [https://github.com/yourusername/vue_marten_project](https://github.com/Csejrup/vue_marten_project.git)
cd my-server

2. Install the dependencies:
dotnet restore

### Configuration

1. Update the `appsettings.json` file with the correct connection string for your PostgreSQL database.

2. Create the necessary tables and objects in your PostgreSQL database by running the following command:
dotnet ef database update

### Development

To start the development server, run:
dotnet run

Now, the Task Management System backend will be running on `http://localhost:5000` (or `https://localhost:5001` if using HTTPS).

### Building

To build the project for production, run:
dotnet build --configuration Release

The built files will be in the `bin/Release` directory.

## Architecture

The "my-server" project follows the Clean Architecture or Onion Architecture pattern, which emphasizes separation of concerns, testability, and maintainability. The architecture consists of the following layers:

1. **Domain Layer**: This layer contains the core business logic and domain entities. It should be independent of any infrastructure concerns or external dependencies. In the Task Management System, this layer would include task and user entities, as well as any domain logic like task validation or task state transitions.

2. **Application Layer**: This layer contains use cases and application services. It is responsible for coordinating the domain layer and infrastructure layer, acting as a bridge between the two. In the Task Management System, this layer would include services to create tasks, update tasks, assign tasks to users, and fetch tasks or task history.

3. **Infrastructure Layer**: This layer includes implementations of external dependencies such as databases, event stores, or third-party services. In the Task Management System, this layer would include the MartenDB event store, PostgreSQL database access, and any other external services needed.

4. **Presentation Layer**: In this case, the presentation layer is a set of API endpoints that serve as the interface for the frontend "My-client" Vue app. This layer will receive API requests, call the appropriate application services, and return responses. In the Task Management System, this layer would include API endpoints for tasks and users, such as creating tasks, updating tasks, assigning tasks, and fetching tasks or task history.

### Folder Structure

The folder structure for the "my-server" project look like this:

my-server/
├── src/
│ ├── Domain/
│ │ ├── Entities/
│ │ └── Interfaces/
│ ├── Application/
│ │ ├── Services/
│ │ └── DTOs/
│ ├── Infrastructure/
│ │ ├── EventStore/
│ │ ├── DataAccess/
│ │ └── ExternalServices/
│ └── Presentation/
│ └── Api/
├── tests/
│ ├── Domain.UnitTests/
│ ├── Application.UnitTests/
│ ├── Infrastructure.IntegrationTests/
│ └── Presentation.Api.Tests/
├── .gitignore
├── README.md
└── my-server.sln

