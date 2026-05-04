# Project Architecture: FinanceTracker

This document outlines the structural design of the FinanceTracker application. The project follows a **Clean Architecture** approach, ensuring a strict separation of concerns where the core business logic is independent of external frameworks.

## 1. Solution Structure

### **Domain Layer**
The innermost layer, containing no external dependencies.
* **Entities:**
    * `BaseEntity`: Common properties for all database objects.
    * `BaseAccount` (Abstract): Core logic for financial accounts.
    * `SavingsAccount` & `CreditCardAccount`: Specific account implementations.
    * `Transaction`: Represents a financial movement.
* **Value Objects:** `Money` (Amount and Currency logic).
* **Enums:** `Currency`, `TransactionType`, `AccountType`.

### **Application Layer**
Contains the business logic and interfaces. This layer sits between the Domain and the outside world.
* **Interfaces:** Defines the contracts for external communication.
    * `IRepositories`: `IAuthRepository`, `IBaseRepository`, `IFinanceRepository`.
    * `Services`: `IAuthService`, `IFinanceService`.
    * `Security`: `IJwtProvider`.
* **Services:** Concrete implementations of business logic (e.g., `AuthService`, `FinanceService`).
* **Dtos:** Data Transfer Objects used for requests and responses.
* **Shared:**
    * **Validators:** FluentValidation rules (e.g., `AddTransactionRequestValidator`, `CreateAccountRequestValidator`).
    * **Common:** `Result.cs` (standardized response wrapper), `JwtSettings.cs`, `CategorySummary.cs`.

### **Infrastructure Layer**
Handles technical concerns and data persistence.
* **Data:** EF Core `DbContext` and Migrations.
* **Repositories:** Implementations of the interfaces defined in the Application layer.
* **Authentication:** JWT token generation logic.
* **BackgroundJobs:** Tasks handled outside the standard request lifecycle.

### **API Layer**
The entry point for the system.
* **Controllers:** RESTful endpoints.
* **Middleware:**
    * Global Exception Handling.
    * CORS configuration.
    * JWT Authorization setup.

### **UI Layer (Blazor WebAssembly)**
The client-side interface.
* **References:** Directly references **Application** for DTOs and Validation logic.
* **Services:** Client-side implementations of `IAuthService` and `IFinanceService` to communicate with the API.

## 2. Dependency Rule
The dependencies point inwards. The **Domain** knows nothing of other layers. The **Application** knows only the **Domain**. The **Infrastructure**, **API**, and **UI** layers depend on the **Application** and **Domain** layers to function.

---
*Last Updated: 2026-05-04*
