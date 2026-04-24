# Month Finder

## Concept

We use months constantly — for birthdays, schedules, events, and planning.  
However, computers do not understand month names like *“January”* or *“April”* directly.  
Instead, they work with numeric values such as `1` or `4`.

This challenge focuses on creating a model that connects **month numbers** to meaningful details:

- The **name** of the month (e.g., `1 → January`)
- The **number of days** in that month (e.g., `April → 30`)

For simplicity, treat **February** as having **28 days**.

---

## The Challenge

1. Create a `Month` class that includes:
   - A data member to store the month number  
   - A method to return the **name** of the month  
   - A method to return the **number of days** in that month  
   - An overridden `ToString()` that displays complete month details  

2. Create a second class (or main program) that:
   - Asks the user to enter a month number  
   - Displays the **month name** and **number of days**  
   - Shows an error message if the month number is not within `1–12`  

---

## Why This Matters

This challenge helps you:

- Represent **real-world concepts** (months) using classes  
- Use methods to generate meaningful information from data  
- Handle **invalid input** safely and correctly  
- Understand how programs can model real-life systems  

Think of this assignment as building a tiny **calendar helper** that bridges how humans think about months and how computers process them.

