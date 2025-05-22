# Driver Achievements API

An ASP.NET Core Web API project demonstrating a **Clean Architecture** with the **Repository Pattern** upgraded to use **CQRS** (Command Query Responsibility Segregation) with **MediatR**.

---

## Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Technologies](#technologies)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- Command and Query separation using MediatR for clean, maintainable code.
- Repository pattern abstracting data access.
- ASP.NET Core Web API with controllers delegating to MediatR handlers.
- AutoMapper for DTO and entity mapping.
- Validation with model state checks.
- Swagger/OpenAPI documentation with rich annotations.
- Support for Driver and Achievement entities with full CRUD operations.
- Unit testing (if included)

---

## Architecture

This project follows the principles of **Clean Architecture** including:

- **API Layer:** Entry point with minimal controllers that delegate to MediatR commands and queries.
- **Application Layer:** Contains Mediator request/response models, handlers, and business logic.
- **Domain Layer:** Entities and domain abstractions.
- **Infrastructure Layer:** Data access implementations, repositories, unit of work.
- **Cross-cutting concerns:** Logging, validation, mapping.

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A supported IDE such as [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- SQL Server or your preferred database configured in your connection string

---

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-repository/driver-achievements-api.git
   cd driver-achievements-api