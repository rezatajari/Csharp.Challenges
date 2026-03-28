# Collections (Arrays) Challenge

## Objective

Practice working with **arrays** in C# by manually implementing aggregation logic  
without using LINQ or higher-level collection utilities.

This challenge reinforces:

- Array creation
- Fixed-size collections
- Index-based iteration
- Manual aggregation
- Edge case handling

---

## Scenario

You are building a simple financial component.

The system receives **exactly 12 monthly transactions**.

Your task is to:

1. Store the 12 transaction values in an array.
2. Calculate:
   - Total
   - Average
   - Minimum
   - Maximum
3. Output the results to the console.

---

## Constraints

- Use `decimal[]`
- Do NOT use LINQ (`Sum()`, `Average()`, `Min()`, `Max()`)
- Do NOT use `List<T>`
- Use manual iteration (`for` loop)
- Handle edge cases:
  - If the array is empty → throw an exception
  - If the array has one element → calculations must still be correct

---

## Expected Learning Outcomes

After completing this task, you should clearly understand:

- How arrays are created and initialized
- How the `Length` property works
- How to iterate safely over an array
- How aggregation works internally
- Why initialization of `min` and `max` must be done carefully
- The difference between fixed-size arrays and dynamic collections

