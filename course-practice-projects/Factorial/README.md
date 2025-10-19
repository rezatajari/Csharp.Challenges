# Factorial Calculator

### Concept

Factorials are widely used in **combinatorics, probability, and mathematics** to represent the product of all positive integers up to a given number. For example, `5! = 5 × 4 × 3 × 2 × 1 = 120`.

This challenge focuses on building a **factorial calculator** that:

### The Challenge

1. Ask the user to **enter a non-negative integer** (or `Q` to quit).
2. Validate the input:

   * Reject invalid values or negative numbers.
   * Prompt again until a valid input is given.
3. Use a **loop** to calculate the factorial of the given number.
4. Support very large results using `BigInteger`.
5. Display the result in the format:

   * `Factorial of N = result`
6. Allow the program to repeat until the user enters `Q`.

**Example Output:**

```
Enter a number to calculate factorial (Q to quit):
5
Factorial of 5 = 120
Q
```

### Why This Matters

This exercise teaches you how to:

* Implement **loops** for iterative calculations.
* Perform **input validation** and handle user errors.
* Work with **BigInteger** for very large calculations.
* Control **program flow** with exit conditions.
