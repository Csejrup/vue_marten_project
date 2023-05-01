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
