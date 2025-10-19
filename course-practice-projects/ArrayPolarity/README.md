# Positive & Negative Arrays with Position Sum

## Concept

Working with multiple arrays and dividing data into categories is a fundamental programming skill. By separating positive and negative values into their own arrays, you gain clearer insight into how data is distributed.

This challenge also introduces **random number generation** and **position-based calculations** across arrays.

## The Challenge

Write a program that:

1. Asks the user for an integer **N** (size of arrays).
2. Creates two arrays of size `N`:

   * One for **positive numbers**
   * One for **negative numbers**
   * Both initialized with zeros.
3. Generates **N random integers** (positive or negative).
4. Stores each random number in the appropriate array:

   * Positive numbers go into the **positive array** at the same index.
   * Negative numbers go into the **negative array** at the same index.
   * If a slot has no value of a type, it remains `0`.
5. Calculates the **position sum** array:

   * Add the numbers at the same index of the two arrays.
   * Store the result in a new array.
6. Displays all three arrays:

   * Positive array
   * Negative array
   * Position sum array

## Example Output

```
Input:
N = 5

Random numbers generated: -2, 3, 5, -5, -2

Positive numbers (5 of them): 0, 3, 5, 0, 0
Negative numbers (5 of them): -2, 0, 0, -5, -2
Position sum of numbers: -2, 3, 5, -5, -2
```

## Input Validation

* Reject **non-numeric input** for `N`.
* Reject if `N <= 0`.
* Prompt the user again if input is invalid.

## Why This Matters

This challenge strengthens your ability to:

* Work with **parallel arrays**.
* Use **random number generation**.
* Apply **conditional logic** to store values.
* Perform **position-wise array operations**.
