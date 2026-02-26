\# CLI Task Manager (High-Level OOP)



A modular, enterprise-ready Command Line Interface (CLI) Task Manager built with \*\*C# 13\*\* and \*\*.NET 9\*\*.



\## 🚀 Module 1: Core Architecture (Days 1–3)

This phase focuses on the \*\*Repository Pattern\*\* and \*\*Generics\*\* to ensure a decoupled and scalable system.



\### Key Technical Achievements:

\- \*\*Abstraction:\*\* Implemented `IRepository<T>` to separate business logic from data access.

\- \*\*Generics \& Constraints:\*\* Utilized `where T : class, IEntity` to create a reusable storage engine.

\- \*\*Asynchronous Design:\*\* Integrated `Task` and `async/await` throughout the data layer for non-blocking operations.

\- \*\*Decoupling:\*\* Ensured the UI (`Program.cs`) remains agnostic of the underlying storage implementation.



\### Folder Structure:

\- `/Interfaces`: Contains the contracts (`IEntity`, `IRepository`).

\- `/Models`: Contains the data blueprints (`ProjectTask`).

\- `/Data`: Contains the implementation logic (`InMemoryRepository`).

