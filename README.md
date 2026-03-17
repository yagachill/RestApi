# RestApi

A REST API built with ASP.NET Core 8 and Entity Framework Core, connected to a SQL Server database.

## Endpoints

| Method | URL | Description |
|--------|-----|-------------|
| GET | /api/users | Get all users (supports `?search=name`) |
| GET | /api/users/{id} | Get user by ID |
| POST | /api/users | Create a new user |
| PUT | /api/users/{id} | Update a user |
| DELETE | /api/users/{id} | Delete a user |

## Models

**User**
- `Id` — primary key
- `Name` — required
- `Email` — optional, must be valid email
- `Number` — optional, must be 8 digits
- `Address` — optional

## Technologies

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
