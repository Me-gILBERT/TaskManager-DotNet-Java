# 🛡️ Task Manager CLI: Enterprise C# Architecture

A professional-grade Command Line Interface (CLI) application built with **.NET 9**. This project serves as a comprehensive demonstration of Clean Architecture, the Repository Pattern, and Defensive Programming in C#.

## 🚀 Module 1 Summary: The Foundation

Over the course of Module 1, the application evolved from a simple console script into a robust, persistent, and "crash-proof" system.

### 🏗️ 1. Structural Design (The "Brain")
* **Repository Pattern:** Implemented a decoupled architecture using `IRepository<T>`. This ensures the UI is entirely independent of the storage implementation.
* **Generics & Abstraction:** Leveraged C# Generics with constraints (`where T : class, IEntity`) to create a reusable data engine capable of handling any entity type.
* **Asynchronous Programming:** Built from the ground up using `async/await` and `Task` to mimic real-world enterprise environments where data operations are non-blocking.



### 💾 2. Persistence & Data Engineering (The "Memory")
* **JSON Serialization:** Integrated `System.Text.Json` to transform live C# objects into persistent storage, ensuring data survives application restarts.
* **Stateless Transaction Logic:** Developed a **Load-Modify-Save** cycle in the `JsonRepository`, maintaining data integrity and ensuring the `.json` file remains the single "Source of Truth."
* **Cross-Platform File I/O:** Utilized `Path.Combine` and `AppDomain` base directories to ensure the application remains portable across Windows, Mac, and Linux environments.



### 🛡️ 3. Defensive Programming (The "Safety")
* **Custom Exceptions:** Developed a domain-specific Exception layer (e.g., `EntityNotFoundException`) to provide meaningful feedback instead of generic system crashes.
* **Guard Clauses:** Implemented logic gates in the Repository layer to intercept invalid requests (e.g., deleting a non-existent ID) before they reach the data file.
* **Input Validation:** Added a validation layer in the UI to prevent "dirty data" (empty titles/whitespace) from entering the persistence layer.
* **Graceful Degradation:** Wrapped the main execution loop in `try-catch` blocks, allowing the app to recover from errors and continue running.



## 🧪 Module 2: Automated Testing & Mocking
Implemented a robust Quality Assurance (QA) layer to ensure application stability and logic verification.

### Technical Achievements:
* **Unit Testing (xUnit):** Developed automated test cases covering the full CRUD lifecycle, ensuring 100% reliability of the Repository logic.
* **Mocking (Moq):** Leveraged the `Moq` library to simulate data-layer dependencies. This allows for high-speed testing by isolating business logic from Physical File I/O.
* **Negative Testing:** Verified that the "Defensive Layer" correctly triggers custom exceptions (`EntityNotFoundException`) when encountering invalid data.
* **Behavioral Verification:** Used Mock Verifications to confirm that the application interacts with the data layer exactly as intended, preventing redundant operations.



### Test Coverage Includes:
- **Happy Path:** Adding, updating, and retrieving tasks.
- **Edge Cases:** Handling empty lists and non-existent IDs.
- **System Failure:** Mocking disk/database errors to test application resilience.

## 🏗️ Module 3: Dependency Injection & Service Layer
Refactored the application architecture to follow the Dependency Inversion Principle (SOLID), moving towards a Service-Oriented Architecture.

### Technical Achievements:
* **Dependency Injection (DI):** Integrated `Microsoft.Extensions.DependencyInjection` to manage object lifecycles and dependencies centrally.
* **Service Layer Pattern:** Introduced a `TaskService` to encapsulate business logic, further decoupling the User Interface from the Data Access Layer.
* **Singleton & Transient Lifetimes:** Leveraged specific service lifetimes to optimize memory usage and ensure data consistency across the application.
* **Clean Architecture:** Successfully removed "hard-coded" dependencies, allowing for seamless swapping of storage engines or UI frameworks.

## 🛠️ Tech Stack & Patterns
* **Framework:** .NET 9 (C# 13)
* **Namespaces:** `System.Text.Json`, `System.IO`, `System.Linq`, `System.Threading.Tasks`
* **Design Patterns:** Repository Pattern, Interface Segregation, Generic Programming, Defensive Programming.

## 📈 Roadmap
- [x] **Module 1:** OOP, Persistence, and Error Handling.
- [ ] **Module 2:** Unit Testing with xUnit and Mocking.
- [ ] **Module 3:** Transitioning to SQL Server with Entity Framework Core.