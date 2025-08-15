# ASP.NET Core MVC Product Management and Approval System

This project is a **product management system** developed using **ASP.NET Core MVC (.NET 8)** and **Entity Framework Core (SQLite)**.  
Users can add products, and administrators can approve or reject them via the admin panel.

## Features

- User authentication (Session-based)
- List, add, edit products
- Admin product approval system
- Role-based authorization (Admin / User)
- SQLite database
- Clean MVC architecture

## Technologies

- **ASP.NET Core MVC (.NET 8)**
- **Entity Framework Core**
- **SQLite**
- **Bootstrap** (UI design)

## Project Structure

WebApp/
├── Controllers/ # MVC Controller files
├── Models/ # Entity and ViewModel classes
├── Views/ # Razor View pages
├── Data/ # EF Core DbContext
├── Migrations/ # EF Core migration files
├── wwwroot/ # Static files (CSS, JS, images)
├── appsettings.json # Application settings
└── Program.cs # Entry point

## Installation

1. Clone the repository:
   bash
   git clone https://github.com/YOUR_USERNAME/aspnet-mvc-product-approval.git

2. Navigate to the project directory:
   cd aspnet-mvc-product-approval/WebApp

3. Install dependencies:
   dotnet restore

4. Create the database:
   dotnet ef database update

5. Run the application:
   dotnet run
