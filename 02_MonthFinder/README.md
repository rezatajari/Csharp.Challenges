# Challenge 02 – Month Finder  

### Concept  
We all use months every day — for birthdays, events, and planning.  
But computers don’t naturally understand *“January”* or *“April”*.  
They work with numbers like `1` or `4`.  

The idea here is to build a small model that connects those **month numbers** to something meaningful:  
- The **name** of the month (e.g., `1 → January`).  
- The **number of days** in that month (e.g., `April → 30`).  

For simplicity, February will always be treated as **28 days**.  

### The Challenge  
1. Create a `Month` class with:  
   - A data member for the month number.  
   - A method to return the **name of the month**.  
   - A method to return the **number of days** in that month.  
   - An overridden `ToString()` method to display month details.  

2. Create a second class that:  
   - Lets the user enter a month number.  
   - Displays the **month name** and **days**.  
   - Shows an error message if the number is invalid (not `1–12`).  

### Why This Matters  
This challenge shows how to:  
- Represent **real-world things (months)** as objects in code.  
- Use methods to provide useful information about those objects.  
- Handle **invalid inputs** gracefully, which is a common task in real applications.  

Think of this program as a **tiny calendar helper** — the code is just the model, but the concept is about how humans and computers can “talk” about months in a shared way.  
