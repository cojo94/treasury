# Treasury

Treasury is a personal finance application built with **.NET 10** and **Blazor** as a portfolio project to explore modern .NET development, Clean Architecture, and full-stack application design.

## Current Status

**Version:** v0.0.1 (Work in Progress)

Current features:

* Initial Blazor dashboard
* Mock financial data
* Reusable UI components
* Clean Architecture solution structure

This project is under active development and will gradually evolve from mock data to a fully functional finance application.

## Planned Features

* Dashboard backed by application services
* PostgreSQL database
* Entity Framework Core
* User authentication & authorization
* Budget management
* Transaction tracking
* Savings goals
* Charts and financial insights

## Tech Stack

Current:

* .NET 10
* Blazor
* Bootstrap

Planned:

* PostgreSQL
* Entity Framework Core
* ASP.NET Core Identity

## Project Structure

```text
Treasury.Application     // Application logic
Treasury.Domain          // Domain models and business rules
Treasury.Infrastructure  // Database and external services
Treasury.Web             // Blazor frontend
```

## Getting Started

### Prerequisites

* .NET 10 SDK

### Run the application

```bash
dotnet watch --project Treasury.Web
```

Then open the URL shown in the terminal (typically `https://localhost:xxxx`).

## License

This project is intended for learning, experimentation, and portfolio purposes.

## Author

cojo94
