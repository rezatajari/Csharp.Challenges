# The Bank Vault (Encapsulation)

## Challenge Overview

This mini-project teaches the principle of **encapsulation** in C#.
You will implement a `BankAccount` class that represents a strict bank vault where the balance is fully protected.

The goal is to ensure the balance can only be changed through controlled methods, mimicking a real-world banking system.

---

## Learning Objectives

* Understand the difference between **private fields** and public methods
* Apply **business rules** when designing a class
* Practice **defensive programming** to prevent invalid operations
* Reinforce **object-oriented thinking** and design-first mindset

---

## Story

Imagine a bank account as a strict vault:

* The account’s money is **private** and cannot be accessed directly
* Only the account itself can change the balance
* All updates happen through **methods** such as AddMoney and RemoveMoney
* The balance **cannot go negative**, but it **can reach zero**
* External code can only interact through these controlled methods

This design models a real-world bank system, rather than a simple data container.

---

## Rules

* Store the balance in a **private field**
* The constructor must initialize the balance safely
* Implement methods to add and remove money following business rules
* Do not expose the balance as a public field
* Use **professional naming conventions**:

  * `_camelCase` for private fields
  * `PascalCase` for methods and public members

---

## Example Scenario

* Initialize the account with a starting balance
* Add a positive amount to increase the balance
* Remove an amount, ensuring the balance never goes below zero
* Attempting to remove more than the balance should be safely prevented

---

## Completion Checklist

* The balance cannot become negative
* The money field is fully private
* All changes go through controlled methods
* The constructor enforces the same rules as the methods
* Naming conventions are professional and consistent

---

## Reflection

Encapsulation solves the problem of uncontrolled access:

* Protects sensitive data from external interference
* Ensures all business rules are enforced in one place
* Allows future features, such as logging or permission checks, without changing external code
