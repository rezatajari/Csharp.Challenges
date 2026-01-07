# MoneyFoundation 

A high-performance, domain-driven banking core built with C# and .NET. This project focuses on building a secure and scalable financial system from the ground up.

---

## Challenge 1: The Atomic Foundation (Complete)

**Goal:** Create a bulletproof "Value Object" system for handling money. In this challenge, we ensure that the system prevents mathematical errors, avoids rounding issues, and maintains domain integrity at the lowest level.

### Task 1: Defining the Currency Identity
In a banking system, a currency is not just a label; it is a weight that defines value.
* **Requirement:** Create a `readonly struct` named `Currency`.
* **Properties:** `Name` (string) and `Rate` (decimal).
* **Validation:**
    * The constructor must throw an exception if the `Name` is null or empty.
    * The constructor must throw an exception if the `Rate` is less than or equal to zero.
* **Equality:** Implement equality operators (`==`, `!=`) to ensure currencies are compared by value, not by reference.



### Task 2: Building the Money Container (Value Object)
"Glue" an amount to a currency to create a meaningful financial unit. 
* **Requirement:** Create a `readonly struct` named `Money`.
* **Properties:** `decimal Amount` and `Currency Currency`.
* **Immutability:** Use `get`-only properties. Once a `Money` instance is created, it cannot be modified; it can only produce a new value through operations.
* **Defensive Design:** Guard against the "Default State" (where `Currency` might be null) by adding validation in the property initialization or constructor.

### Task 3: Enforcing Mathematical Safety (Operator Overloading)
Teach the system the "Laws of the Bank" to prevent illegal operations.
* **Addition (+):** Allow adding two `Money` objects **only if** they share the same `Currency`. Throw an `InvalidOperationException` if a mismatch occurs.
* **Subtraction (-):** Allow subtraction with the same currency validation. 
* **Equality (==):** Implement equality so that `100 USD` is exactly equal to another instance of `100 USD`, but never equal to `100 Rial`.



---

## Technical Topics Applied
* **Readonly Structs:** Memory-efficient stack allocation.
* **Immutability:** Ensuring thread-safety and preventing accidental data changes.
* **Operator Overloading:** Providing a clean, expressive math-like API.
* **Semantic Data Modeling:** Linking raw numbers to their domain context (Currency).
* **Defensive Programming:** Using "Fail-Fast" logic to catch errors at the source.

---

# Challenge 2: The Bank Account Entity

## Overview
In this challenge, we transitioned from simple **Value Objects** to a robust **Domain Entity**. The focus was on protecting the "State" of an account and ensuring that every financial movement is traceable and valid.

##  Architectural Decisions

### 1. Entity vs. Value Object
We designed `Account` as a **Class** (Reference Type). 
* **Reasoning:** A bank account has a unique **Identity** (Account Number) that stays the same even if the data (Balance) changes. It must be shared across the system without being copied.

### 2. The "Twin-Storage" Encapsulation
To protect the transaction history, we used the **Private Workhorse / Public Window** pattern:
* **Private:** `List<Transaction> _transactions` allows the `Account` class to record history.
* **Public:** `IReadOnlyList<Transaction> Transactions` allows outside users to view history without the ability to `Add()` or `Clear()` records.



### 3. Fail-Fast Guard Clauses
We implemented strict validation at the "Entry Points" (Constructor and Methods):
* **Null Checks:** Prevent "Zombie Accounts" by ensuring `User` and `Currency` are valid upon creation.
* **Domain Rules:** Prevent currency mismatch and unauthorized overdrafts before the balance is ever touched.

## Components

| Component | Type | Responsibility |
| :--- | :--- | :--- |
| `Account` | **Class** | Manages balance, enforces rules, and owns the history. |
| `Transaction` | **Readonly Struct** | Captures a "Snapshot" of a move (Amount, Type, Time). |
| `TransactionType`| **Enum** | Categorizes moves (Deposit, Withdrawal, Transfer). |

##  Data Integrity Example
```csharp
// Recalculating balance from history to verify state
public Money GetVerifiedBalance()
{
    decimal total = 0;
    foreach(var tx in _transactions)
    {
        if (tx.Type == TransactionType.Deposit) total += tx.Amount.Amount;
        else total -= tx.Amount.Amount;
    }
    return new Money(total, Currency);
}


---

# Challenge 3: The Bank Management System

## Overview
In this challenge, we moved from managing a single **Account** to building a **Bank** system. This required handling collections of entities and coordinating interactions between two different objects (Transfers).

## Architectural Decisions

### 1. The Registry (Storage)
We implemented a private collection within the `Bank` class to manage account lifecycles.
* **Encapsulation:** The list of accounts is `private`. The only way to interact with an account is through the Bank's verified methods (`GetAccount`).
* **Identity-Based Lookup:** We used **LINQ** (`FirstOrDefault`) to retrieve accounts by their unique `Number`.

### 2. Transactional Atomicity (The Transfer)
The biggest challenge was ensuring that money doesn't "disappear" during a transfer. We implemented the **Validate-All-Then-Act** pattern:
* **Pre-Execution Guards:** We verify the currency compatibility of the Source, the Destination, AND the Money object before a single cent is withdrawn.
* **Safety:** If the destination account is incompatible, the process throws an exception *before* the source account is debited.



### 3. Factory Pattern
The `Bank` acts as a factory for accounts. Instead of the user manually creating an `Account` object, the `Bank.OpenAccount` method handles:
1. Validation of the User and Currency.
2. Instantiation of the Account.
3. Registration in the internal "Vault."
4. Returning the `AccountNumber` as the unique handle for the user.

## Components

| Component | Responsibility |
| :--- | :--- |
| `Bank` | The Orchestrator. Manages account storage and inter-account transfers. |
| `LINQ` | Used for efficient searching within