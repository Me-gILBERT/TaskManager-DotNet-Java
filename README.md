# 🛡️ Task Manager CLI: Enterprise C# & .NET 9 Architecture

A professional-grade Command Line Interface (CLI) application demonstrating **Clean Architecture**, **SOLID principles**, and **Relational Data Persistence**. This project evolved through four intensive modules, moving from a simple script to a robust, test-verified enterprise foundation.

---

## 🏗️ Module 1: Structural Foundations & Defensive Coding

The goal was to build a system that is both modular and "crash-proof."

- **Repository Pattern:** Implemented `IRepository<T>` to decouple the User Interface from data access logic.
- **Generics:** Leveraged C# Generics with type constraints (`where T : class, IEntity`) for a reusable data engine.
- **Defensive Layer:** Developed custom **Exception Middleware** (e.g., `EntityNotFoundException`) and Guard Clauses to ensure application stability against invalid user inputs.

---

## 🧪 Module 2: Quality Assurance (xUnit & Moq)

Architecture is nothing without verification. This module focused on automated testing.

- **Unit Testing:** Built a comprehensive suite using **xUnit** to verify the core CRUD lifecycle.
- **Mocking:** Utilized **Moq** to simulate the data layer, allowing for lightning-fast tests that execute in memory without touching the physical disk.
- **Negative Testing:** Specifically tested failure states to ensure the "Defensive Layer" correctly intercepts and reports system errors.

---

## 💉 Module 3: Dependency Injection & Service Layer

Refactored the application into a Service-Oriented Architecture (SOA) to achieve true loose coupling.

- **Inversion of Control (IoC):** Integrated `Microsoft.Extensions.DependencyInjection` to manage object lifetimes (**Singleton**, **Scoped**, and **Transient**).
- **Service Layer:** Introduced a `TaskService` to encapsulate business logic, ensuring the `Program.cs` (UI) remains "thin" and focused only on user interaction.
- **Dependency Inversion:** Removed all hard-coded dependencies, allowing the system to be highly extensible and testable.

---

## 🗄️ Module 4: Relational Persistence (EF Core & SQL)

Successfully transitioned from local JSON file storage to a professional relational database architecture using **Entity Framework Core**.

### Technical Achievements:

- **Object-Relational Mapping (ORM):** Implemented `AppDbContext` to map C# POCO classes to a **SQLite** database schema, eliminating manual serialization logic.
- **Code-First Migrations:** Managed database schema evolution using **EF Core Migrations**, ensuring version-controlled data structures.
- **Runtime Schema Verification:** Integrated `Database.EnsureCreated()` to guarantee database and table existence at application startup.
- **Architectural Flexibility:** Demonstrated the power of **Dependency Injection** by swapping the storage provider from JSON to SQL with zero changes required in the `TaskService` or UI layers.

---

## 🌐 Module 5: ASP.NET Core Web API (In Progress)

Transitioning the application from a local CLI tool to a modern, scalable RESTful Web Service.

### Objectives:

- **REST API Design:** Implementing standard HTTP verbs (GET, POST, PUT, DELETE).
- **Cross-Project Integration:** Sharing the Domain and Logic layers between the CLI and Web API projects.
- **Swagger/OpenAPI:** Documenting the API endpoints for third-party consumption.

---

## 🛠️ Tech Stack & Skills

- **Language:** C# 13 (.NET 9)
- **Data Layer:** Entity Framework Core, SQLite, JSON Serialization
- **Testing:** xUnit, Moq, Fluent Assertions
- **Patterns:** SOLID Principles, Repository Pattern, Dependency Injection, Clean Architecture

---

## 📈 Roadmap

- [x] Module 1: OOP & Defensive Programming
- [x] Module 2: Automated Unit Testing
- [x] Module 3: Dependency Injection & Service Layers
- [x] Module 4: SQL Database Integration (EF Core)
- [ ] **Next:** Module 5: ASP.NET Core Web API (RESTful Services)
