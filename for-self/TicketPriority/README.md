
# Refactor-Safe Title Change Notification

## Scenario

You are building a simple ticket system.

Each `Ticket` has a `Title`.

When the `Title` changes, the system must:

* Detect the change
* Notify subscribers
* Print which property changed

The system must remain correct even if the property is renamed later.

---

## Business Rule

If the `Title` changes, the application should print:

```
Title changed
```

If the same value is assigned again, nothing should happen.

---

## Technical Constraints

* Implement `INotifyPropertyChanged`
* Do NOT use auto-properties for `Title`
* Use a private backing field
* Raise the event only when the value actually changes
* Use `nameof(Title)` (no hard-coded strings)

---

## Expected Flow

1. Create a `Ticket`
2. Subscribe to `PropertyChanged`
3. Change `Title`
4. Console prints:

```
Title changed
```

---

## Refactoring Test

Rename:

```
Title → IssueTitle
```

The system must still work without manually updating any string.

If logging breaks, the implementation is incorrect.

---

## Reflection Questions

1. Why is `nameof(Title)` safer than `"Title"`?
2. What happens if you remove the value comparison in the setter?
3. Why should the `Ticket` class not print directly to the console?

---

## Definition of Done

* No magic strings
* Event fires only when value changes
* Refactoring does not break behavior
* Code compiles cleanly
