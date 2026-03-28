# The Rectangular Vault

## Overview

In this task, we moved away from dynamic collections (`List`) to a **Fixed-Space Data Structure**. We simulated a physical safety deposit vault using a **Rectangular Array**.

## Architectural Decisions

### 1. The "Solid Block" Memory Model

Unlike a `List<List<int>>` (which is an object containing other objects), the `int[5, 10]` is a **single object** in memory.

* **Performance:** The computer calculates the exact memory address of a box using a simple formula: `BaseAddress + (row * TotalColumns + col)`. This makes access incredibly fast.
* **Type Safety:** The type `int[,]` is distinct from `int[]`. You cannot accidentally pass a one-dimensional list into a method expecting this grid.

### 2. Zero-Based Grid Coordinate System

We applied the standard C# indexing rules to a 2D space:

* The **First Box** is at coordinate `[0, 0]`.
* The **Last Box** (in a 5x10 grid) is at `[4, 9]`.

## Components

| Component | Responsibility |
| --- | --- |
| `int[,] _boxes` | Stores user IDs in a contiguous memory block. |
| `AssignBox` | Maps a physical location (Row/Col) to a specific Owner ID. |
| `GetOwner` | Retrieves the value using coordinate-based indexing. |

## Key Takeaways for a Junior Developer

* **Rectangular Arrays** are best when the "Shape" of your data is fixed and never changes (like a chessboard or a theater seating chart).
* **Simplicity:** You don't need to initialize each row individually; C# allocates the entire block at once.
* **Constraints:** You cannot have "jagged" rows. Every row in your vault must have exactly 10 columns.
