# Universal Translator (Generic Numeric Operations)

## Overview

This challenge focuses on designing a **generic and type-safe numeric operation** in C# that works across multiple numeric types without relying on runtime checks or type casting.

The goal is to understand **why and when generics with constraints should be used**, and how modern C# enables writing logic that behaves consistently for all numeric types.

---

## Problem Statement

In real applications, we often need to apply the **same business rule** to different numeric types such as:

* `int`
* `decimal`
* `double`

A naive approach would require:

* Multiple overloaded methods, or
* Runtime type checks, or
* Unsafe casting

All of these approaches reduce maintainability and correctness.

---

## Objective

Design a single method that:

* Accepts **any numeric type**
* Rejects non-numeric types **at compile time**
* Applies a shared business rule (doubling the value)
* Returns the result **in the same numeric type**
* Avoids runtime validation for invalid types

---

## Key Concepts Practiced

* Generic methods
* Generic constraints
* `INumber<T>` interface
* Compile-time safety over runtime checks
* Designing APIs that model real-world rules

---

## Design Principles

* **Encapsulation of behavior**
  Numeric behavior is grouped into a dedicated translator class.

* **Compiler-enforced correctness**
  Invalid types (such as `string`) are rejected by the compiler, not by exceptions.

* **Single responsibility**
  The method focuses only on numeric transformation, not validation of unrelated types.

---

## Expected Behavior

* Numeric inputs are doubled correctly.
* The returned value preserves the original numeric type.
* Non-numeric types cannot be passed to the method.
* No runtime type checks or error messages are required for invalid types.

---

## Learning Outcome

After completing this challenge, you should clearly understand:

* Why generic constraints are more powerful than `if` checks
* How modern C# supports generic math
* How to design APIs that prevent invalid usage by design
* How to think in terms of **type systems**, not just syntax

---

## Next Step

Proceed to the next challenge, where we will explore:

* Stronger modeling of intent
* Reducing object creation overhead
* Improving expressiveness through modern C# features

---

**Challenge Level:** Beginner → Intermediate
**Focus:** Design thinking, not memorization
