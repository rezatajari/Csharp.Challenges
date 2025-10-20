# Lucian's Luscious Lasagna

Lucian’s girlfriend is on her way home, and he hasn’t cooked their anniversary dinner yet!  
Your task is to help Lucian prepare an exquisite lasagna by writing a simple program that manages cooking times.

This exercise introduces **basic class design** and **method creation** in C#.  
You’ll complete a series of tasks, each one building on the previous.

---

## Learning Objectives
- Understand how to create and use a class.  
- Define and call methods.  
- Pass and handle parameters.  
- Return calculated values.  
- Combine methods together for reusability.

---

## Tasks

### Task 1: Define the expected oven time
Create a method that returns how long the lasagna should stay in the oven according to the recipe.

**Requirements**
- Method name: `ExpectedMinutesInOven`
- Takes no parameters
- Returns the expected oven time in minutes

---

### Task 2: Calculate the remaining oven time
Create a method that tells how many minutes remain for the lasagna to finish baking.

**Requirements**
- Method name: `RemainingMinutesInOven`
- Takes one parameter: the number of minutes already in the oven
- Returns remaining time based on the expected oven time

---

### Task 3: Calculate the preparation time
Create a method that returns how long Lucian spent preparing the lasagna layers.

**Requirements**
- Method name: `PreparationTimeInMinutes`
- Takes one parameter: the number of layers added
- Each layer takes 2 minutes to prepare
- Returns total preparation time

---

### Task 4: Calculate the total elapsed time
Create a method that combines preparation time and baking time to get the total time spent cooking so far.

**Requirements**
- Method name: `ElapsedTimeInMinutes`
- Takes two parameters:
  1. Number of layers added  
  2. Minutes the lasagna has been in the oven  
- Returns total elapsed time (preparation time + oven time)

---

## Hint
Use previously defined methods inside your later ones to avoid repeating logic.  
This follows the **DRY (Don’t Repeat Yourself)** principle of clean coding.

---

## Summary
By completing this exercise, you will:
- Build your first C# class  
- Learn method definitions, parameters, and return values  
- Practice clean and maintainable code design  

---

## Optional Extension
Add friendly console output messages (e.g., when the lasagna will be ready)  
or experiment with different preparation times per layer.

---

**Good luck, Chef Developer! **
