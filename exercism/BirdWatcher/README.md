# Bird Watcher 

This repository contains solutions for the **Bird Watcher** exercises from Exercism (C# track). The goal is to track the number of birds visiting a garden over a week and implement different operations on this data using object-oriented programming.

---

## Problem Description

You are an avid bird watcher that keeps track of how many birds have visited your garden in the last seven days. The exercises are centered around the `BirdCount` class, which stores the daily bird counts and provides methods to analyze them.

### Tasks

1. **Last Week's Counts**  
   Implement a static method `BirdCount.LastWeek()` that returns the counts from last week.  
   **Last week's counts:**  
[0, 2, 5, 3, 7, 8, 4]

2. **Today's Count**  
Implement `BirdCount.Today()` to return the number of birds that visited **today**.  
- The first element in the array is the oldest day.  
- The last element is today.

3. **Increment Today's Count**  
Implement `BirdCount.IncrementTodaysCount()` to increase the number of birds that visited today by one.

4. **Check for Day Without Birds**  
Implement `BirdCount.HasDayWithoutBirds()` to return `true` if there was any day with **0 birds**, otherwise `false`.

5. **Count for First Days**  
Implement `BirdCount.CountForFirstDays(int days)` to calculate the total number of birds that visited the garden for the first `n` days of the week.

6. **Busy Days**  
Implement `BirdCount.BusyDays()` to count the number of **busy days**, where a busy day is defined as having **five or more birds** visiting the garden.

---

## Example Usage

```csharp
int[] birdsThisWeek = { 2, 5, 0, 7, 4, 1, 3 };
var birdCount = new BirdCount(birdsThisWeek);

Console.WriteLine(birdCount.Today());             // Output: 3
birdCount.IncrementTodaysCount();
Console.WriteLine(birdCount.Today());             // Output: 4
Console.WriteLine(birdCount.HasDayWithoutBirds()); // Output: True
Console.WriteLine(birdCount.CountForFirstDays(4)); // Output: 14
Console.WriteLine(birdCount.BusyDays());           // Output: 3
Console.WriteLine(string.Join(", ", BirdCount.LastWeek())); // Output: 0, 2, 5, 3, 7, 8, 4
