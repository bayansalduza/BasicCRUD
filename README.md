# BasicCRUD

**BasicCRUD** is a modular, layered architecture project built with ASP.NET Core. It demonstrates how to implement CRUD (Create, Read, Update, Delete) operations in a clean and scalable structure. It also includes a robust logging system powered by **Serilog** for detailed monitoring and error tracking.

---

## Project Structure

The project is organized into the following layers to ensure separation of concerns and maintainability:

1. **BasicCRUD.Api**  
   - The presentation layer that exposes endpoints to interact with the application.
   - Manages HTTP requests and responses.

2. **BasicCRUD.Application**  
   - Handles the application logic and enforces business rules.
   - Interacts with the domain and infrastructure layers.

3. **BasicCRUD.Domain**  
   - Defines core business logic, domain entities, and value objects.
   - Represents the core of the application.

4. **BasicCRUD.Infrastructure**  
   - Responsible for data access and persistence.
   - Implements repositories and connects to the database.

5. **BasicCRUD.Shared**  
   - Contains shared utilities, constants, and common helpers used across all layers.

---

## Technologies Used

- **.NET Core 8**
- **Entity Framework Core** (for database interaction)
- **SQL Server** (as the database)
- **FluentValidation** (for model validation)
- **Serilog** (for structured logging and error tracking)
- **Swagger/OpenAPI** (for API documentation)

---

## Features

- CRUD operations for domain entities.
- Clean, modular architecture based on Domain-Driven Design (DDD) principles.
- **Integrated logging system powered by Serilog**:
  - Logs errors to a file (`logs/error-log-.txt`) with daily rolling intervals.
  - Outputs logs to the console for real-time monitoring.
  - Configured to log only error-level messages or higher.
- Dependency Injection for scalability and testability.
- Comprehensive Swagger documentation for API exploration.
