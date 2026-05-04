# API Endpoints Documentation

This document describes the RESTful API endpoints available in the FinanceTracker system. All endpoints utilize a standardized `Result<T>` wrapper for consistent error handling and response structure.

---

## **Global Controller Logic**
All controllers inherit from `ApiControllerBase`, which centralizes core functionality:
* **UserId Resolution:** A protected property that extracts and parses the `NameIdentifier` claim from the current user's JWT. It throws an `UnauthorizedAccessException` if the claim is missing or invalid.
* **HandleResult<T>:** A helper method that converts the application's `Result<T>` objects into appropriate `IActionResult` responses (e.g., `200 OK` for success, or `400/404/401 Problem` for failures).

---

## **1. Authentication (AuthController)**
**Base Route:** `/api/auth`  
*Public access (no authorization required).*

| Method | Endpoint | Description | Request Body |
| :--- | :--- | :--- | :--- |
| **POST** | `/register` | Registers a new user in the system. | `RegisterUserRequest` |
| **POST** | `/login` | Validates credentials and returns a JWT for subsequent requests. | `LoginUserRequest` |

---

## **2. Finance Management (FinanceController)**
**Base Route:** `/api/finance`  
*Authorization (JWT) is required for all endpoints.*

### **Account Management**
| Method | Endpoint | Description | Details |
| :--- | :--- | :--- | :--- |
| **POST** | `/create-account` | Creates a new account for the authenticated user. | `CreateAccountRequest` |
| **GET** | `/accounts` | Lists all accounts belonging to the current user. | Returns `List<AccountResponse>` |
| **GET** | `/account/{id}` | Retrieves details for a specific account. | Path Parameter: `id` (int) |
| **DELETE** | `/delete/{id}` | Permanently deletes an account and associated data. | Path Parameter: `id` (int) |

### **Transactions**
| Method | Endpoint | Description | Details |
| :--- | :--- | :--- | :--- |
| **GET** | `/transaction/{id}` | Fetches transaction history for a specific account. | Path Parameter: `id` (AccountId) |
| **POST** | `/transaction` | Records a new Income, Expense, or Transfer. | `AddTransactionRequest` |

### **Dashboard & Insights**
| Method | Endpoint | Description | Details |
| :--- | :--- | :--- | :--- |
| **GET** | `/dashboard` | Provides summarized financial data for the UI overview. | Total Balances, Summaries |

---

## **Standard Response Format**
Successful requests return the requested data directly. Failed requests return a standard **Problem Details** (RFC 7807) response:

```json
{
  "title": "Bad Request",
  "status": 400,
  "detail": "Descriptive error message from the business logic",
  "type": "[https://tools.ietf.org/html/rfc7231#section-6.5.1](https://tools.ietf.org/html/rfc7231#section-6.5.1)"
}
```

---
*Last Updated: 2026-05-04*
"""
