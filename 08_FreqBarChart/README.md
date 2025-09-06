# Challenge 08 – Frequency Distribution Bar Chart

## Concept

Analyzing the frequency of values in a dataset is a key skill in data analysis. Visualizing frequencies using simple bar charts can quickly reveal patterns and trends in data.

This challenge focuses on **dynamic input**, **array usage**, **input validation**, and **basic visualization**.

## The Challenge

Write a program that:

1. Allows the user to enter any number of values between **0 and 10**.
2. Stops accepting input when the user chooses to stop (for example, by entering a special keyword like `"done"`).
3. Keeps track of the **frequency of each number**.
4. Displays a **frequency distribution bar chart** using asterisks (`*`) to represent counts.

### Requirements

* If a number is not entered at all, the corresponding line should **not display any asterisks**.
* Show error messages for:

  * Values outside the range `0–10`
  * Non-numeric input

## Example Output

```
Enter a number between 0 and 10 (or 'done' to finish): 3
Enter a number between 0 and 10 (or 'done' to finish): 7
Enter a number between 0 and 10 (or 'done' to finish): 3
Enter a number between 0 and 10 (or 'done' to finish): done

Frequency Distribution:
0:
1:
2:
3: **
4:
5:
6:
7: *
8:
9:
10:
```

## Input Validation

* Reject any **number outside the 0–10 range**.
* Reject **non-numeric input** (except the stop keyword, e.g., `"done"`).
* Prompt the user to **re-enter** if input is invalid.

## Why This Matters

This exercise teaches you how to:

* Handle **dynamic arrays** and store multiple values.
* Perform **frequency counting**.
* Build **basic visualizations** in the terminal.
* Implement **robust input validation**.
