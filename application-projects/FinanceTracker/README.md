# FinanceTracker

A modern, clean-architecture personal finance management system built with **.NET 8**, **Blazor WebAssembly**, and **Entity Framework Core**.

## Project Overview

The FinanceTracker is designed as a lightweight yet robust tool for users to manage their financial health. From a requirement perspective, the application focuses on three core pillars:
1.  **Account Management:** Supporting multiple account types (Savings and Credit) with specialized logic for each (e.g., Credit Limits).
2.  **Transaction Integrity:** Recording precise movements of funds (Income, Expense, and Transfers) with category-based tracking.
3.  **Real-time Insights:** Providing a dashboard overview of total balances and spending patterns.

The system emphasizes security via **JWT Authentication** and reliability through a **Global Exception Handling** middleware.

---

## Minimal Setup

To get the application running locally in three steps:

1.  **Database:** Update the connection string in `Api/appsettings.json` and run the migrations:
    ```bash
    dotnet ef database update --project Infrastructure --startup-project Api
    ```
2.  **Configuration:** Ensure `JwtSettings` in `Api/appsettings.json` has a secure `Secret`.
3.  **Launch:** Start both the **Api** and **UI** projects (Multiple Startup Projects in Visual Studio).

---

## Detailed Documentation

The project documentation is organized into three primary sections to assist with development and maintenance:

* [**Architecture & Design**](./doc/architecture.md): A deep dive into the Clean Architecture layers (Domain, Application, Infrastructure, Api, and UI) and the dependency rules followed.
* [**API Endpoints**](./doc/api-endpoints.md): A technical reference for all RESTful routes, request/response DTOs, and the standardized error handling logic.
* [**Full Setup Guide**](./doc/setup-guide.md): Detailed instructions on prerequisites, environment configuration, and troubleshooting common installation issues.

---
*Created as part of the C# Challenges Project.*