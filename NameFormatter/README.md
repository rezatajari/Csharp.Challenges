# Challenge 17 – Name Formatter (Windows Form)

### Concept

This challenge focuses on **Windows Forms input handling** and **string formatting**.
You’ll build an application that takes multiple user inputs and displays **all possible name formats** in a **ListView** when a button is clicked.

### The Challenge

1. Create a **Windows Form** application with the following input controls:

   * TextBox for **First Name**
   * TextBox for **Middle Name**
   * TextBox for **Last Name**
   * TextBox or ComboBox for **Title** (Mr., Mrs., Ms., Dr., etc.)
2. Add a **single Button** labeled e.g., `Format Name`.
3. Add a **ListView control** to display the formatted names.
4. When the button is clicked, the program should display the following formats in the ListView:

| Name Format                                          |
| ---------------------------------------------------- |
| Title First Middle Last → `Ms. Kelly Jane Smith`     |
| First Middle Last → `Kelly Jane Smith`               |
| First Last → `Kelly Smith`                           |
| Last, First Middle, Title → `Smith, Kelly Jane, Ms.` |
| Last, First Middle → `Smith, Kelly Jane`             |
| Last, First → `Smith, Kelly`                         |

5. Ensure the program **handles missing input gracefully** and updates the ListView correctly.

**Example Input:**

```
First: Kelly
Middle: Jane
Last: Smith
Title: Ms.
```

**Example Output (ListView):**

```
Ms. Kelly Jane Smith
Kelly Jane Smith
Kelly Smith
Smith, Kelly Jane, Ms.
Smith, Kelly Jane
Smith, Kelly
```

### Why This Matters

This exercise teaches you how to:

* Handle **user input** from multiple controls.
* Perform **string concatenation and formatting**.
* Populate a **ListView dynamically**.
* Update UI based on a **single action event**.