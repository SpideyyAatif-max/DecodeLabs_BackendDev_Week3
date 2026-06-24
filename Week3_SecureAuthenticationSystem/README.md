# Secure Authentication System

ASP.NET Core Web API project for Backend Development Project 3.

## Features

- User registration
- Password hashing before saving to database
- User login
- JWT token generation after successful login
- Protected routes using `[Authorize]`
- SQL Server database using Entity Framework Core

## Folder Structure

```text
SecureAuthenticationSystem/
├── Controllers/
│   └── AuthController.cs
├── Data/
│   └── AppDbContext.cs
├── Database/
│   └── schema.sql
├── DTOs/
│   ├── AuthResponse.cs
│   ├── LoginRequest.cs
│   ├── RegisterRequest.cs
│   └── UserProfileResponse.cs
├── Models/
│   └── User.cs
├── Properties/
│   └── launchSettings.json
├── Services/
│   ├── AuthService.cs
│   └── IAuthService.cs
├── appsettings.Development.json
├── appsettings.json
├── Program.cs
├── SecureAuthenticationSystem.csproj
└── README.md
```

## Requirements

- .NET 8 SDK
- SQL Server installed locally
- Git

## Database Setup

The project uses this connection string in `appsettings.json`:

```json
"DefaultConnection": "Server=localhost;Database=SecureAuthDb;Trusted_Connection=True;TrustServerCertificate=True;"
```

If you use SQL Server Express, change it to:

```json
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=SecureAuthDb;Trusted_Connection=True;TrustServerCertificate=True;"
```

If you use LocalDB, change it to:

```json
"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=SecureAuthDb;Trusted_Connection=True;TrustServerCertificate=True;"
```

The project creates the database tables automatically using `db.Database.EnsureCreated()` in `Program.cs`.

## Run the Project Without Visual Studio

Open terminal inside the project folder and run:

```bash
dotnet restore
dotnet run
```

Then open:

```text
http://localhost:5045/swagger
```

## API Endpoints

### Register

```http
POST /api/auth/register
```

Body:

```json
{
  "name": "Danish",
  "email": "danish@example.com",
  "password": "Password123"
}
```

### Login

```http
POST /api/auth/login
```

Body:

```json
{
  "email": "danish@example.com",
  "password": "Password123"
}
```

Copy the token from the login response.

### Protected Profile Route

```http
GET /api/auth/profile
```

Header:

```http
Authorization: Bearer YOUR_TOKEN_HERE
```

### Protected Test Route

```http
GET /api/auth/protected
```

Header:

```http
Authorization: Bearer YOUR_TOKEN_HERE
```

## GitHub Upload Commands

```bash
git init
git add .
git commit -m "Add secure authentication system"
git branch -M main
git remote add origin https://github.com/YOUR_USERNAME/SecureAuthenticationSystem.git
git push -u origin main
```

## Notes

- Passwords are never stored as plain text.
- Passwords are hashed using BCrypt.
- JWT is generated only after successful login.
- Protected routes require a valid JWT token.
- Change the JWT secret key before production use.
