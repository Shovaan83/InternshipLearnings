# Support Ticket Management System

A modern, real-time support ticket management system built with .NET 8 and Razor Pages. This application allows users to create, manage, and communicate through support tickets with real-time chat functionality.

## Features

- **Support Ticket Management**
  - Create and track support tickets
  - View ticket history
  - FAQ integration
  - Real-time status updates

- **Live Chat System**
  - Real-time communication between users and support staff
  - Persistent chat history
  - Automatic reconnection handling
  - User-friendly interface

- **User Management**
  - User authentication and authorization
  - Role-based access control
  - User profile management
  - Branch and counter management

## Technical Stack

- **Framework**: .NET 8
- **Architecture**: Razor Pages
- **Database Access**: Dapper
- **Real-time Communications**: SignalR
- **Frontend**: 
  - Bootstrap
  - JavaScript
  - SignalR client

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server (or your configured database)
- Visual Studio 2022 or preferred IDE

### Installation

1. Clone the repository
2. Navigate to the project directory and restore dependencies
3. Update the database connection string in `appsettings.json`
4. Run the application

## Project Structure

- `Controllers/` - Contains MVC controllers for user and service ticket management
- `Models/` - Data models and ViewModels
- `Views/` - Razor views and pages
- `Services/` - Business logic and data access services
- `Hubs/` - SignalR hubs for real-time communication

## Configuration

The application uses standard ASP.NET Core configuration patterns. Key settings can be found in:
- `appsettings.json` - Main configuration file
- `Program.cs` - Application startup and service configuration

## Security

- HTTPS enforcement enabled
- HSTS implemented for production
- Authorization middleware configured
- Secure WebSocket connections for real-time communication

## Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

