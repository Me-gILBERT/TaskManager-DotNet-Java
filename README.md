# 🛡️ Task Manager CLI: Enterprise OOP Patterns

A modular Task Management system built with **.NET 9**, demonstrating professional software architecture, the Repository Pattern, and data persistence.

## 🏗️ Architecture & Core Logic (Days 1–3)
The foundation of this project is built on **Decoupling** and **Generics** to ensure the system is scalable and easy to maintain.

* **Repository Pattern:** Implemented `IRepository<T>` to separate business logic from data access. This allows the UI to remain agnostic of how data is stored.
* **Generic Constraints:** Utilized `where T : class, IEntity` to create a "Shape-Shifter" storage engine that can handle any model (Tasks, Bible Summaries, etc.) as long as it has a unique `Id`.
* **Interface-Driven Development:** Defined `IEntity` as a mandatory contract for all data models, ensuring type safety across the application.
* **Asynchronous Flow:** Integrated `Task` and `async/await` to simulate non-blocking operations, a requirement for modern enterprise-grade applications.



## 💾 Persistence Layer (Days 4–5)
Transitioned the application from volatile RAM storage to persistent disk storage using JSON.

* **Serialization:** Integrated `System.Text.Json` to transform live C# objects into structured text files.
* **Stateless CRUD Operations:** Developed a **Load-Modify-Save** cycle in the `JsonRepository` to ensure data integrity and persistence across application restarts.
* **Path Resilience:** Leveraged `Path.Combine` and `AppDomain.CurrentDomain.BaseDirectory` to ensure the file system remains compatible across different operating systems.
* **Encapsulation:** Used private helper methods for File I/O, exposing only the necessary interface methods to the rest of the application.



## 🛠️ Technical Stack
* **Framework:** .NET 9 (C# 13)
* **Namespaces:** `System.Text.Json`, `System.IO`, `System.Linq`, `System.Threading.Tasks`
* **Patterns:** Repository Pattern, Generic Programming, Interface Segregation

## 🚀 Future Roadmap
- [ ] **Module 1 (Days 6–7):** Porting the logic to **Java** to demonstrate cross-language architectural mastery.
- [ ] **Module 2:** Implementing Unit Testing to validate the storage engine.
- [ ] **Module 3:** Transitioning to a SQL Database (Entity Framework Core).

---
*Developed as part of a 2026 High-Level OOP Mastery Module.*
