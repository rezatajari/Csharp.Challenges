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